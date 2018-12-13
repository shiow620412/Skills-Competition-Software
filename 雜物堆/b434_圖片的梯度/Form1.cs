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
namespace b434_圖片的梯度
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                Bitmap source = new Bitmap(ofd.FileName);
                Bitmap destination = new Bitmap(source.Width, source.Height);
                for (int i = 0; i < destination.Width;i++)
                    for(int j=0;j< destination.Height;j++)
                    {
                        if (i + 1 >= destination.Width | j + 1 >= destination.Height)
                        {
                            destination.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                            continue;
                        }
                        Color sC = source.GetPixel(i, j);
                        Color dxC = source.GetPixel(i + 1, j);
                        Color dyC = source.GetPixel(i, j + 1);
                        int dCr = (Math.Abs(dxC.R - sC.R) + Math.Abs(dyC.R - sC.R)) / 2;
                        int dCg = (Math.Abs(dxC.G - sC.G) + Math.Abs(dyC.G - sC.G)) / 2;
                        int dCb = (Math.Abs(dxC.B - sC.B) + Math.Abs(dyC.B - sC.B)) / 2;
                        destination.SetPixel(i, j, Color.FromArgb(dCr, dCg, dCb));
                    }
                
                pictureBox1.Image = source;
                pictureBox2.Image = destination;
            }
        }
    }
}
