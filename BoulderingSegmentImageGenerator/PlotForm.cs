using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoulderingSegmentImageGenerator
{
    public partial class PlotForm : Form
    {
        public PlotForm()
        {
            InitializeComponent();
        }

        public void Plot(double[] x, double[] y)
        {
            fp.Plot.Clear();
            var sp1 = fp.Plot.AddScatter(x, y);
            sp1.MarkerShape = ScottPlot.MarkerShape.openCircle;
            fp.Refresh();
        }
    }
}
