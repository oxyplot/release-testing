namespace WindowsFormsApp1
{
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using OxyPlot.WindowsForms;
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var pm = new PlotModel
            {
                Title = "Test"
            };
            pm.Axes.Add(new LinearAxis { Title = "Bottom", Position = AxisPosition.Bottom, AxisTitleDistance = 10 });
            pm.Axes.Add(new LinearAxis { Title = "Left", Position = AxisPosition.Left });
            pm.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.01));

            var pv = new PlotView
            {
                Model = pm,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pv);
        }

    }
}
