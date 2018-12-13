using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬練習101_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.TranslateTransform(200, 200);
            g.DrawLine(Pens.Black, -200, 0, 200, 0);
            g.DrawLine(Pens.Black, 0, -200, 0, 200);
            for (int i = -200; i <= 200; i += 20)
            {
                if (i == 0)
                    continue;
                g.FillEllipse(Brushes.Black, i, -2.5f, 5, 5);
                g.FillEllipse(Brushes.Black, -2.5f, i, 5, 5);
            }
            g.FillEllipse(Brushes.Black, -2.5f, -2.5f, 5, 5);
            PointF p1, p2;
            float[] temp = Array.ConvertAll(textBox1.Text.Split(','),float.Parse);
            p1 = new PointF(temp[0], temp[1]);
            temp = Array.ConvertAll(textBox2.Text.Split(','), float.Parse);
            p2 = new PointF(temp[0], temp[1]);
            g.DrawLine(Pens.Black, p1.X*2,-p1.Y*2, p2.X*2,-p2.Y*2);
            PointF p3, p4;
            temp = Array.ConvertAll(textBox3.Text.Split(','), float.Parse);
            p3 = new PointF(temp[0], temp[1] );
            temp = Array.ConvertAll(textBox4.Text.Split(','), float.Parse);
            p4 = new PointF(temp[0], temp[1] );
            g.DrawLine(Pens.Black, p3.X*2,-p3.Y*2, p4.X*2,-p4.Y*2);

            double a = p2.Y - p1.Y;
            double b = -(p2.X - p1.X);
            double c = -p1.Y*p2.X+p1.X*p2.Y;

            double d =p4.Y-p3.Y;
            double _e = -(p4.X - p3.X); 
            double f = -p3.Y*p4.X+p3.X*p4.Y;

            double N = (c * _e - b * f) / (a * _e - b * d);
            double O = (c * d - a * f) / (b * d - a * _e);

            bool Line1X=false, Line1Y = false, Line2X = false, Line2Y = false;
            float min = Math.Min(p1.X, p2.X);
            float max = Math.Max(p1.X, p2.X);
            if (min <= N && max >= N)
                Line1X = true;
            min = Math.Min(p1.Y, p2.Y);
            max = Math.Max(p1.Y, p2.Y);
            if (min <= O && max >= O)
                Line1Y = true;
            min = Math.Min(p3.X, p4.X);
            max = Math.Max(p3.X, p4.X);
            if (min <= N && max >= N)
                Line2X = true;
            min = Math.Min(p3.Y, p4.Y);
            max = Math.Max(p3.Y, p4.Y);
            if (min <= O && max >= O)
                Line2Y = true;
            if (Line1X && Line1Y && Line2X && Line2Y)
            {
                textBox5.Text = "有相交";
                textBox6.Text = $"{N.ToString("0.00")},{O.ToString("0.00")}";
            }
            else
            {
                textBox5.Text = "無相交";
                textBox6.Text = "";
            }
            
        }
    }
}
