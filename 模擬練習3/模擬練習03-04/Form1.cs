using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬練習03_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { InitialDirectory = System.IO.Directory.GetCurrentDirectory() };
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap source = new Bitmap(pictureBox1.Image);
            Bitmap destination = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < source.Width; i++)
            {
                for(int j =0;j<source.Height;j++)
                {
                    Color c = source.GetPixel(i, j);
                    if (c.R == 255 && c.G == 255 && c.B == 255)
                        continue;
                    for(int m=-1;m<2;m++)
                        for(int n =-1;n<2;n++)
                        {
                            int vx = i + m;
                            int vy = j + n;
                            if (vx < 0 | vy < 0 | vx >= source.Width | vy >= source.Height)
                                continue;
                            destination.SetPixel(vx, vy, Color.Black);
                        }

                        
                }
            }
            pictureBox1.Image = destination;
        }
    }
}
