namespace ConsoleApp1
{
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var pm = new PlotModel
            {
                Title = "Test"
            };
            pm.Axes.Add(new LinearAxis { Title = "Bottom", Position = AxisPosition.Bottom, AxisTitleDistance = 10 });
            pm.Axes.Add(new LinearAxis { Title = "Left", Position = AxisPosition.Left });
            pm.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.01));
            var e = new PdfExporter();
            e.Width = 800;
            e.Height = 500;
            e.Background = OxyColors.LightBlue;
            var path = "test.pdf";
            using (var stream = File.Create(path))
                e.Export(pm, stream);
            // Process.Start(path);
        }
    }
}
