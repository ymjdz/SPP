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

namespace SinglePointPositioning
{
    public partial class Paint : Form
    {
        public Paint()
        {
            InitializeComponent();
        }

        private void Paint_Load(object sender, EventArgs e)
        {
            double[] x = new double[ReceiverPositionSum.receiverPositionSum.Count];
            double[] y = new double[ReceiverPositionSum.receiverPositionSum.Count];
            double[] z = new double[ReceiverPositionSum.receiverPositionSum.Count];


            for (int i = 0; i < ReceiverPositionSum.receiverPositionSum.Count; i++)
            {
                x[i] = ReceiverPositionSum.receiverPositionSum[i].X - ReceiverPositionSum.receiverPositionSum[0].X;
                y[i] = ReceiverPositionSum.receiverPositionSum[i].Y - ReceiverPositionSum.receiverPositionSum[0].Y;
                z[i] = ReceiverPositionSum.receiverPositionSum[i].Z - ReceiverPositionSum.receiverPositionSum[0].Z;
            }
            chart1.Series.Clear();
            Series series1 = new Series("X");
            Series series2 = new Series("Y");
            Series series3 = new Series("Z");
            //series1.Color = Color.Blue;
            //series2.Color = Color.Red;
            //series3.Color = Color.Green;
            series1.ChartType = SeriesChartType.FastLine;
            series2.ChartType = SeriesChartType.FastLine;
            series3.ChartType = SeriesChartType.FastLine;
            for (int i = 0; i < x.Length; i++)
            {
                series1.Points.AddY(x[i]);
                series2.Points.AddY(y[i]);
                series3.Points.AddY(z[i]);
            }
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.Series.Add(series3);
        }
    }
}
