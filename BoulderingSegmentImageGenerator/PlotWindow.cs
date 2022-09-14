using ScottPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderingSegmentImageGenerator
{
    class PlotWindow
    {
        public PlotWindow()
        {
            init();
        }

        ~PlotWindow()
        {
            if (form == null)
                return;

            form.Dispose();
        }

        [Conditional("DEBUG")]
        private void init()
        {
            form = new PlotForm();
            form.Show();
        }

        [Conditional("DEBUG")]
        public void AddData(List<Point> points)
        {
            if (form == null)
                return;

            double[] x = new double[points.Count];
            double[] y = new double[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                x[i] = points[i].X;
                y[i] = points[i].Y;
            }

            form.Plot(x, y);
        }

        private PlotForm form = null;
    }
}
