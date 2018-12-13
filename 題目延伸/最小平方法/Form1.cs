using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 最小平方法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float[] x = Array.ConvertAll(textBox1.Text.Split(' '), float.Parse);
            float[] y = Array.ConvertAll(textBox2.Text.Split(' '), float.Parse);
            chart1.Series.Clear();
            chart1.Series.Add("data");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series[0].Points.AddXY(x[i], y[i]);
            }
            float xbar = x.Average();
            float ybar = y.Average();
            float b1 = 0;
            float up=0,down=0;
            for (int i = 0; i < x.Length; i++)
            {
                up += (x[i]-xbar) * (y[i]-ybar);
                down += (float)Math.Pow(x[i] - xbar, 2);
            }
            b1 = up / down;
            float b0 = ybar - b1 * xbar;

            chart1.Series.Add("line");
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for(float i = x.Min();i<= x.Max();i+=0.1f)
            {
                chart1.Series[1].Points.AddXY(i, b0 + b1 * i);
            }
        }
    }
}
