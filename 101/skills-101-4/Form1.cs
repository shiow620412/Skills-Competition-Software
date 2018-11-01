using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_101_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(bmp);
            g.TranslateTransform(200, 200);
            g.DrawLine(Pens.Black, -200, 0, 200, 0);
            g.DrawLine(Pens.Black, 0, -200, 0, 200);
            pictureBox1.Image = bmp;
            for (int i = -200; i <= 200; i += 20)
            {
                g.DrawLine(Pens.Black, i, -2, i, 2);
                g.DrawLine(Pens.Black, -2, i, 2, i);
            }
            g.DrawString("(-100,0)", Font, Brushes.Black, -200, 10);
            g.DrawString("(100,0)", Font, Brushes.Black, 200, 10);
            g.DrawString("(0,100)", Font, Brushes.Black, 10, -200);
            g.DrawString("(0,-100)", Font, Brushes.Black, 10, 200);
            g.DrawString("(0,0)", Font, Brushes.Black, 5, 5);
            int[] input = Array.ConvertAll(textBox1.Text.Split(','), int.Parse);
            Point p11 = new Point(input[0] * 2, -input[1] * 2);
            input = Array.ConvertAll(textBox2.Text.Split(','), int.Parse);
            Point p12 = new Point(input[0] * 2, -input[1] * 2);
            input = Array.ConvertAll(textBox3.Text.Split(','), int.Parse);
            Point p21 = new Point(input[0] * 2, -input[1] * 2);
            input = Array.ConvertAll(textBox4.Text.Split(','), int.Parse);
            Point p22 = new Point(input[0] * 2, -input[1] * 2);
            g.DrawLine(Pens.Black, p11, p12);
            g.DrawLine(Pens.Black, p21, p22);

            float a = p12.Y - p11.Y;
            float b = -(p12.X - p11.X);
            float c = -p11.Y * p12.X + p11.X * p12.Y;
            float d = p22.Y - p21.Y;
            float _e = -(p22.X - p21.X);
            float f = -p21.Y * p22.X + p21.X * p22.Y;
            float N = (c * _e - b * f) / (a * _e - b * d);
            float O = (c * d - a * f) / (b * d - a * _e);

            bool isdotX = false;
            int min = Math.Min(p11.X, p12.X);
            int max = Math.Max(p11.X, p12.X);
            if (N >= min && N <= max)
                isdotX = true;
            bool isdotY = false;
            min = Math.Min(p11.Y, p12.Y);
            max = Math.Max(p11.Y, p12.Y);
            if (O >= min && O <= max)
                isdotY = true;
            if (isdotX && isdotY)
            {
                textBox6.Text = $"{N / 2},{-O / 2}";
                textBox5.Text = "有相交";
            }
            else
            {
                textBox6.Text = "";
                textBox5.Text = "未相交";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1000, 1000);
            pictureBox1.Image = bmp;
            List<TextBox> txt = Controls.OfType<TextBox>().ToList();
            txt.ForEach(x => x.Clear());
        }
    }
}
