using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class mainForm : Form
    {
        private string _imgFileName;

        public mainForm()
        {
            InitializeComponent();
            cmboTechnique.SelectedIndex = 0;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the title of the dialog
            openFileDialog.Title = "Select an Image File";

            // Set the filter to only allow image files
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";

            // Set the initial directory to the project directory
            string projectDirectory = "D:\\Collection\\Special\\Faculty\\Senior\\Computer Vision\\Practical\\Oral\\images";
            openFileDialog.InitialDirectory = projectDirectory;

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name and display it in a TextBox or any other control
                txtImagePath.Text = openFileDialog.FileName;

                // You can also load the image into a PictureBox or any other control
                _imgFileName = openFileDialog.FileName;
                imgBoxInput.Image = Image.FromFile(_imgFileName);

                displayInputHistogram();
            }
        }

        void displayInputHistogram()
        {
            pnl_chart_input.Controls.Clear();

            if (_imgFileName != null)
            {
                Enhancementer en = new Enhancementer(_imgFileName);
                var chart = en.GetHistogram();
                pnl_chart_input.Controls.Add(chart);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (_imgFileName != null)
            {
                Enhancementer enhancer = new Enhancementer(_imgFileName);

                if (cmboTechnique.SelectedIndex == 0)
                {
                    //Histogram Equalization
                    var output = enhancer.HistogramEquaization();

                    outputResult(output);
                }
                else if (cmboTechnique.SelectedIndex == 1)
                {
                    //Convolution

                    var outputModel = enhancer.ConvolutionSharpen();

                    outputResult(outputModel);

                }
            }
        }

        void outputResult(ImageModel model)
        {
            pnl_chart_output.Controls.Clear();

            imgBoxOutput.Image = model.Image;
            pnl_chart_output.Controls.Add(model.Histogram);
        }
    }
}
