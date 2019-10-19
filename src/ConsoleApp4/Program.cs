namespace ConsoleApp4
{
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.OpenXml;
    using OxyPlot.Reporting;
    using OxyPlot.Series;
    using System;
    using System.IO;
    using System.Threading;

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
            var path = "test.docx";
            var r = new Report();
            r.AddPlot(pm, "Plot test", 800, 500);
            var rs = new ReportStyle();
            Action export = () =>
            {
                using (var w = new WordDocumentReportWriter(path))
                {
                    w.WriteReport(r, rs);
                    w.Save();
                }
            };

            var thread = new Thread(new ThreadStart(export));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Process.Start(path);
        }
    }
}
