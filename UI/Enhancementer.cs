using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public class Enhancementer
    {
        private readonly string _imgPath;

        public Enhancementer(string imgPath)
        {
            _imgPath = imgPath;
        }


        public ImageModel HistogramEquaization()
        {
            var outputImage=new ImageModel();

            outputImage.FilePath = _imgPath;

            var img = new Bitmap(_imgPath);

            int [,] hist;

            outputImage.Image = histogramEqulize(img,out hist);

            outputImage.Histogram = getHistogramChart(hist);

            return outputImage;
        }

        public Chart GetHistogram()
        {
            var img = new Bitmap(_imgPath);
            var hist = getHistogram(img);
            return getHistogramChart(hist);
        }

        private int[,] getHistogram(Bitmap bitmap)
        {
            int[,] histogram = new int[256, 3];

            int width = bitmap.Width;
            int height = bitmap.Height;

            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * height;
            byte[] rgbValues = new byte[bytes];


            Marshal.Copy(ptr, rgbValues, 0, bytes);


            for (int y=0; y < height; y++)
            {
                for(int x=0; x < width; x++)
                {
                    int index = y * bmpData.Stride + 3 * x;

                    // Access the RGB values for the current pixel
                    byte blue = rgbValues[index];
                    byte green = rgbValues[index + 1];
                    byte red = rgbValues[index + 2];

                    histogram[red, 0]++;
                    histogram[green, 1]++;
                    histogram[blue, 2]++;
                }
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the input image
            bitmap.UnlockBits(bmpData);

            return histogram;
        }

        private Bitmap histogramEqulize(Bitmap inputImage, out int[,] outputHistogram)
        {
            var hist = getHistogram(inputImage);

            int width = inputImage.Width;
            int height = inputImage.Height;
            int size=width * height;

            float[,] Cdf = getCDF(hist, size);


            BitmapData bmpData = inputImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * height;
            byte[] rgbValues = new byte[bytes];

            Marshal.Copy(ptr, rgbValues, 0, bytes);


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    int index = y * bmpData.Stride + 3 * x;


                    byte blue = rgbValues[index];
                    byte green = rgbValues[index + 1];
                    byte red = rgbValues[index + 2];

                    //Mathematical process
                    float RCdf = Cdf[red, 0];
                    float GCdf = Cdf[green, 1];
                    float BCdf = Cdf[blue, 2];

                    red = Math.Min((byte)255, (byte)Math.Floor(255 * RCdf));
                    green = Math.Min((byte)255, (byte)Math.Floor(255 * GCdf));
                    blue = Math.Min((byte)255, (byte)Math.Floor(255 * BCdf));



                    rgbValues[index] = blue;
                    rgbValues[index + 1] = green;
                    rgbValues[index + 2] = red;
                }
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);

            inputImage.UnlockBits(bmpData);

            outputHistogram= getHistogram(inputImage);
            return inputImage;
        }

        private float[,] getCDF(int[,] hist,int size)
        {
            float[,] Cdf = new float[256, 3];

            float prevR = 0f;
            float prevG = 0f;
            float prevB = 0f;

            for (int i=0;i<256;i++)
            {
                int R = hist[i, 0];
                int G = hist[i, 1];
                int B = hist[i, 2];

                //Red
                Cdf[i, 0] = ((float)R / (float)size) + prevR;
                prevR = Cdf[i, 0];

                //Green
                Cdf[i, 1] = ((float)G / (float)size) + prevG;
                prevG = Cdf[i, 1];

                //Blue
                Cdf[i, 2] = ((float)B / (float)size) + prevB;
                prevB = Cdf[i, 2];


            }

            return Cdf;
        }

        private Chart getHistogramChart(int[,] histogram)
        {
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Create a new ChartArea
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 255;
            chartArea.AxisY.Minimum = 0;

            chart.ChartAreas.Add(chartArea);

            // Create a series and add data points
            Series series = new Series("RGB");

            for(int i=0;i<256;i++)
            {
                var redPoint = new DataPoint(i, histogram[i, 0]);
                redPoint.Color=Color.Red;

                var greenPoint = new DataPoint(i, histogram[i, 1]);
                redPoint.Color = Color.Green;

                var bluePoint = new DataPoint(i, histogram[i, 2]);
                redPoint.Color = Color.Blue;


                series.Points.Add(redPoint);
                series.Points.Add(greenPoint);
                series.Points.Add(bluePoint);
            }
            // Add the series to the chart
            chart.Series.Add(series);

            chart.Width = 400;
            chart.Height = 200;

            return chart;
        }

        //convolution
        public ImageModel ConvolutionSharpen()
        {
            //Convolution

            Bitmap inputBitmap = new Bitmap(_imgPath);

            //this kernel is for sharpening the image
            //double[,] kernel = {
            //            { 0,-1,0 },
            //            { -1,5,-1},
            //            { 0,-1,0}
            //        };

            double[,] kernel =
            {
                {-1,0,1 },
                {-2,0,2 },
                {-1,0,1 }
            };


            Bitmap outputBitmap = applyConvolution(inputBitmap, kernel);

            ImageModel outputModel = new ImageModel();
            outputModel.FilePath = _imgPath;

            outputModel.Image = outputBitmap;
            var hist = getHistogram(outputBitmap);

            outputModel.Histogram = getHistogramChart(hist);

            return outputModel;
        }

        private Bitmap applyConvolution(Bitmap inputBitmap, double[,] kernel)
        {
            int width = inputBitmap.Width;
            int height = inputBitmap.Height;

            Bitmap outputBitmap = new Bitmap(width, height);

            // Lock the bits of the input and output bitmaps
            BitmapData inputData = inputBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData outputData = outputBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // Get the stride (bytes per row) for both bitmaps
            int inputStride = inputData.Stride;
            int outputStride = outputData.Stride;

            // Calculate the number of bytes per pixel
            int bytesPerPixel = 4;

            // Create a buffer to hold the pixel data
            byte[] inputDataBuffer = new byte[inputStride * height];
            byte[] outputDataBuffer = new byte[outputStride * height];

            // Copy the pixel data from the input bitmap to the buffer
            System.Runtime.InteropServices.Marshal.Copy(inputData.Scan0, inputDataBuffer, 0, inputDataBuffer.Length);

            // Apply convolution
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    double red = 0, green = 0, blue = 0;

                    // Convolution operation
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int offsetX = x + kx;
                            int offsetY = y + ky;

                            int index = (offsetY * inputStride) + (offsetX * bytesPerPixel);

                            red += inputDataBuffer[index + 2] * kernel[ky + 1, kx + 1];
                            green += inputDataBuffer[index + 1] * kernel[ky + 1, kx + 1];
                            blue += inputDataBuffer[index] * kernel[ky + 1, kx + 1];
                        }
                    }

                    int currentIndex = (y * outputStride) + (x * bytesPerPixel);
                    outputDataBuffer[currentIndex + 2] = (byte)Clamp((int)red, 0, 255);
                    outputDataBuffer[currentIndex + 1] = (byte)Clamp((int)green, 0, 255);
                    outputDataBuffer[currentIndex] = (byte)Clamp((int)blue, 0, 255);
                    outputDataBuffer[currentIndex + 3] = 255; // Alpha channel
                }
            }

            // Copy the processed data back to the output bitmap
            System.Runtime.InteropServices.Marshal.Copy(outputDataBuffer, 0, outputData.Scan0, outputDataBuffer.Length);

            // Unlock the bits of both bitmaps
            inputBitmap.UnlockBits(inputData);
            outputBitmap.UnlockBits(outputData);

            return outputBitmap;
        }

        private int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }
}
