using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public class ImageModel
    {
        public string FilePath { get; set; }

        public Bitmap Image { get; set; }

        public Chart Histogram { get; set; }
    }
}
