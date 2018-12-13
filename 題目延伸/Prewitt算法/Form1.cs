using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wind.MemoryBitmap;
using System.IO;
namespace Prewitt算法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { InitialDirectory = Directory.GetCurrentDirectory() };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MemoryBitmap mbp = new MemoryBitmap(new Bitmap(pictureBox1.Image));
            MemoryBitmap output = new MemoryBitmap(new Bitmap(pictureBox1.Image));
            int[] xModel = new int[] { 1, 1, 1, 0, 0, 0, -1, -1, -1 };
            int[] yModel = new int[] { -1, 0, 1, -1, 0, 1, -1, 0, 1 };
            mbp.Gray();

            for (int i = 0; i < mbp.Height; i++)
            {
                for (int j = 0; j < mbp.Width; j++)
                {
                    int index = 0;
                    int Gx = 0, Gy = 0;
                    for (int m = -1; m < 2; m++)
                    {
                        for (int n = -1; n < 2; n++)
                        {

                            int vx = j + n >= mbp.Width ? j * 2 - mbp.Width : j + n;
                            int vy = i + m >= mbp.Height ? i * 2 - mbp.Height : i + m;


                            if (vx < 0) vx *= -1;
                            if (vy < 0) vy *= -1;

                            int val = mbp.GetPixel(vx, vy).R;
                            Gx += val * xModel[index];
                            Gy += val * yModel[index];
                            index++;
                        }
                    }
                    Gx = Math.Abs(Gx);
                    Gy = Math.Abs(Gy);
                    int p = Math.Max(Gx, Gy);
                    output.SetPixel(j, i, p, p, p);
                }
            }
            output.SaveMemory();
            pictureBox2.Image = output.bmp;

        }



    }
}
