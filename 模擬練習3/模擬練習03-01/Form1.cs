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

namespace 模擬練習03_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float[] input = Array.ConvertAll(textBox1.Text.Split(','), float.Parse);
            Array.Sort(input);
            float mid = input.Length % 2 == 0 ? (input[input.Length / 2] + input[input.Length / 2 - 1]) / 2 : input[input.Length / 2 ];
            int len = input.Length;
            float Q1 = 0.25 * len % 1 != 0 ? input[(int)(0.25 * len / 1) + 1] : (input[(int)(0.25 * len)] + input[(int)(0.25 * len) + 1]) / 2;
            float Q2 = 0.5 * len % 1 != 0 ? input[(int)(0.5 * len / 1) + 1] : (input[(int)(0.5 * len)] + input[(int)(0.5 * len) + 1]) / 2;
            float Q3 = 0.75 * len % 1 != 0 ? input[(int)(0.75 * len / 1) + 1] : (input[(int)(0.75 * len)] + input[(int)(0.75 * len) + 1]) / 2;
            float IQR = Q3 - Q1;
            float limitMin = Q1 - IQR;
            float limitMax = Q3 + IQR;

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            float max = input[len-1];
            float min = input[0];
            g.TranslateTransform(20, 20);
            int count = 0;
            int scale = 5;
            g.DrawLine(Pens.Black, 0, 0, 0, (max - min)*scale);
            for(float i= min;i<= max;i++)
            {

                if (count % 2 == 0)
                {
                    g.DrawLine(Pens.Black, 0, count * scale, 10, count * scale);
                    g.DrawString(i.ToString(), Font, Brushes.Black, -20, count * scale-6);
                }
                if(i == (int)limitMin)
                {
                    g.DrawLine(Pens.Black, 30, count * scale, 40, count * scale);
                }
                if (i == (int)limitMax)
                {
                    g.DrawLine(Pens.Black, 30, count * scale, 40, count * scale);
                }
                if (i == (int)Q1)
                    g.DrawLine(Pens.Blue, 20, count * scale, 50, count * scale);
                if (i == (int)Q3)
                    g.DrawLine(Pens.Blue, 20, count * scale, 50, count * scale);
                count++;

            }
                      
            Series s = new Series();
            s.Enabled = false;
            s.Name = "test";
            for (int i = 0; i < input.Length; i++)
                s.Points.Add(input[i]);
            //s.IsVisibleInLegend = false;
            chart1.Series.Clear(); 
            chart1.Series.Add(s);
            //BoxPlotのSeriesを生成
            Series boxPlotSeries = new Series("BoxPlot");
            boxPlotSeries.ChartType = SeriesChartType.BoxPlot;
            
            //箱ひげ図のSeriesとデータを保持するSeriesの紐づけ
            //(複数のSeriesを指定する場合はSeries名を;区切りで指定する。)
            boxPlotSeries["BoxPlotSeries"] = "test";
            //string.Join(";",seriesList.Select(x => { return x.Name; }).ToArray());
            //ChartにBoxPlotSeriesを追加
            chart1.Series.Add(boxPlotSeries);


        }
    }
}
