using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace skills_103_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        data[] d;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string[] input = File.ReadAllLines(ofd.FileName);
                d = new data[int.Parse(input[0].Split(' ')[0])];
               
                for (int i =1;i< input.Length;i++)
                {
                    double[] temp = Array.ConvertAll(input[i].Split(' '), double.Parse);
                    d[i-1] = new data(temp[0], temp[1]);
                    d[i - 1].No = i - 1;
                    textBox1.Text += $"{i - 1}\t{d[i-1].weight}\t{d[i-1].height}\r\n";
                }
            }
        }
        class data
        {
            public int No;
            public double weight;
            public double height;
            public double Nweight;
            public double Nheight;
            public data(double w, double h)
            {
                this.weight = w;
                this.height = h;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double muH=0, alphaH=0;
            double muW =0, alphaW=0;
            for(int i=0;i<d.Length;i++)
            {
                muH += d[i].height;
                muW += d[i].weight;
            }
            muH /= d.Length;
            muW /= d.Length;
            for(int i = 0; i < d.Length;i++)
            {
                alphaH += Math.Pow(d[i].height - muH, 2);
                alphaW += Math.Pow(d[i].weight - muW, 2);
            }
            alphaH /= d.Length;
            alphaW /= d.Length;
            for(int i=0;i<d.Length;i++)
            {
                d[i].Nheight = (d[i].height - muH) / alphaH;
                d[i].Nweight = (d[i].weight - muW) / alphaW;
            }
            List<data> s1 = new List<data>();
            List<data> s2 = new List<data>();
            List<data> s3 = new List<data>();
            s1.Add(d[0]);
            s2.Add(d[1]);
            s3.Add(d[2]);
            List<data>[] l = new List<data>[3];
            l[0] = s1;
            l[1] = s2;
            l[2] = s3;
            Random rnd = new Random();
            for(int i = 3;i< d.Length;i++)
            {
                l[rnd.Next(0, 3)].Add(d[i]);
            }
            data[] avg = new data[3];
            for(int i =0;i<199;i++)
            {
               
                for(int j=0;j<3;j++)
                {
                    double avgh = 0, avgw = 0;
                    if (l[j].Count > 0)
                    {
                        avgh = l[j].Average(x => x.Nheight);
                        avgw = l[j].Average(x => x.Nweight);
                    }
                    avg[j] = new data(avgw, avgh);
                }
                s1.Clear();s2.Clear();s3.Clear();
                for(int j =0; j<d.Length;j++)
                {
                    double min =99999;
                    int close = 0;
                    for (int m =0;m<3;m++)
                    {
                         double distance = Math.Sqrt(Math.Pow(d[j].Nheight - avg[m].height, 2) + Math.Pow(d[j].Nweight - avg[m].weight, 2));
                        if (min > distance)
                        {
                            min = distance;
                            close = m;
                        }
                    }
                    l[close].Add(d[j]);                    
                }
            }
            int[] sort = new int[d.Length];
            l[0].ForEach((x) =>
            {
                textBox3.Text += $"{x.No}\t{x.weight}\t{x.height}\r\n";
                sort[x.No] = 0;
            });                                   
            l[1].ForEach((x) =>                   
            {                                     
                textBox4.Text += $"{x.No}\t{x.weight}\t{x.height}\r\n";
                sort[x.No] = 1;
            });                                   
            l[2].ForEach((x) =>                   
            {                                     
                textBox5.Text += $"{x.No}\t{x.weight}\t{x.height}\r\n";
                sort[x.No] = 2;
            });
            for (int i = 0; i < sort.Length; i++) textBox2.Text += $"第{i}筆\t屬於{sort[i]}堆\r\n";
        }
    }
}
