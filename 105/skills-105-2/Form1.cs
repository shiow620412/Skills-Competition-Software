using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_105_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double d = 0;
        int split = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                double min = 9999999;
                bool isImg = false;
                for (int i = 100; i < bmp.Width; i++)
                {
                    isImg = false;
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        Color c = bmp.GetPixel(i, j);
                        double colorVal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11;
                        if (colorVal < 200)
                            isImg = true;
                    }
                    if(!isImg)
                    {
                        split = i;
                        break;
                    }
                }
                for (int i=0;i<split;i++)
                    for(int j = 0;j<bmp.Height;j++)
                    {
                        Color c = bmp.GetPixel(i, j);
                        double colorVal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11;
                        if (colorVal < 200 && min > j)
                            min = j;
                    }
                double max = 0;
                for (int i = 0; i < split; i++)
                    for (int j = bmp.Height-1; j >-1; j--)
                    {
                        Color c = bmp.GetPixel(i, j);
                        double colorVal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11;
                        if (colorVal < 200 && max < j)
                            max = j;
                    }
                d = 830/(max - min) ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            double min = 9999999;
            for (int i = split; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    double colorVal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11;
                    if (colorVal < 200 && min > j)
                        min = j;
                }
            double max = 0;
            for (int i = split; i < bmp.Width; i++)
                for (int j = bmp.Height - 1; j > -1; j--)
                {
                    Color c = bmp.GetPixel(i, j);
                    double colorVal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11;
                    if (colorVal < 200 && max < j)
                        max = j;
                }
            label1.Text = ((max - min) * d).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            double min = 9999999;
            for (int i = 0; i < bmp.Height; i++)
                for (int j = split; j < bmp.Width; j++)
                {
                    Color c = bmp.GetPixel(j, i);
                    double colorVal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11;
                    if (colorVal < 200 && min > j)
                        min = j;
                }
            double max = 0;
            for (int i = 0; i < bmp.Height; i++)
                for (int j = bmp.Width-1; j >99; j--)
                {
                    Color c = bmp.GetPixel(j, i);
                    double colorVal = c.R * 0.3 + c.G * 0.59 + c.B * 0.11;
                    if (colorVal < 200 && max < j)
                        max = j;
                }
            label2.Text = ((max - min) * d).ToString();
        }
    }
}
