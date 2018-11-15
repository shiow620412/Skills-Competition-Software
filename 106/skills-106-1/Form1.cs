using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_106_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Data[] d;
        int Q;
        List<double> mse = new List<double>();
        private void button2_Click(object sender, EventArgs e)
        {
            int P = 0;
             Q= int.Parse(textBox2.Text);
            Random rnd = new Random();
            int g1 = rnd.Next(0, 15);
            int g2 = rnd.Next(0, 15);
            while (g1 == g2) g2 = rnd.Next(0, 15);
            Data[] g = new Data[] { d[g1], d[g2] };
            mse.Clear();
            List<Data>[] two = new List<Data>[] { new List<Data>(), new List<Data>() };
            while(Q>P)
            {
                Array.ForEach(two, x => x.Clear());
                for(int i = 0; i<d.Length;i++)
                {
                    double min = 99999999;
                    int tempIndex=0;
                    for (int j = 0; j < g.Length; j++)
                    {
                        double distance = getDistance(d[i], g[j]);
                        if(min> distance)
                        {
                            min = distance;
                            tempIndex = j;                           
                        }
                    }
                    d[i].Index = tempIndex;
                    two[tempIndex].Add(d[i]);
                }
                for(int i = 0; i<g.Length;i++)
                {
                    double avgM = two[i].Average(x => x.Math);
                    double avgE = two[i].Average(x => x.English);
                    g[i] = new Data(avgM, avgE);
                }
                double dMSE=0;
                for (int i = 0;i<2;i++)
                {
                    List<Data> temp = two[i];
                   
                    foreach(var item in temp)
                    {
                        double dx = item.Math - g[i].Math;
                        double dy = item.English - g[i].English;
                        dMSE += Math.Sqrt(dx * dx + dy * dy) / d.Length;
                    }
                }
                mse.Add(dMSE);
                P++;
            }
            textBox5.Clear();
            foreach (var i in d)
                textBox5.Text += i.Index.ToString().PadLeft(4);
        }
        //int[] test = new int[] { 28, 67, 66, 12, 41, 28, 72, 28, 90, 83, 39, 50, 69, 83, 61 };
        //int[] test2 = new int[] { 57, 33, 46, 71, 88, 72, 2, 67, 44, 44, 12, 81, 32, 25, 34 };
        private void button1_Click(object sender, EventArgs e)
        {
            int N = int.Parse(textBox1.Text);
            d = new Data[N];
            textBox3.Clear();
            textBox4.Clear();
            Random rnd = new Random();
            for(int i =0;i<d.Length;i++)
            {
                d[i] = new Data(rnd.Next(0, 101), rnd.Next(0, 101));                
                //d[i] = new Data(test[i], test2[i]);
                textBox3.Text += d[i].Math.ToString().PadLeft(4);                
                textBox4.Text += d[i].English.ToString().PadLeft(4);
            }
        }
        double getDistance(Data data, Data g)
        {
            return Math.Sqrt(Math.Pow(data.Math - g.Math, 2) + Math.Pow(data.English - g.English, 2));
        }
        class Data
        {
            public double Math;
            public double English;
            public int Index;
            public Data(double Math, double English)
            {
                this.Math = Math;
                this.English = English;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ct.Series.Clear();
            ct.Series.Add("MSE");
            ct.ChartAreas[0].AxisX.Maximum = Q-1;
            ct.ChartAreas[0].AxisX.Minimum = 0;
            ct.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ct.Series[0].Points.Clear();
            foreach (var item in mse.Select((x, y) => new { x, y }))
            {
                ct.Series[0].Points.AddXY(item.y,item.x);
                
            }
                
        }
    }
}

