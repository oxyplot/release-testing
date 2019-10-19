using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;

namespace WpfApp2
{
    public class MainViewModel
    {
        public PlotModel Model
        {
            get
            {
                var pm = new PlotModel
                {
                    Title = "Test"
                };
                pm.Axes.Add(new LinearAxis { Title = "Bottom", Position = AxisPosition.Bottom, AxisTitleDistance = 10 });
                pm.Axes.Add(new LinearAxis
                {
                    Title = "Left",
                    Position = AxisPosition.Left
                });
                pm.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.01));
                return pm;
            }
        }
    }
}
