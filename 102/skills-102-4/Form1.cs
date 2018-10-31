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
namespace skills_102_4
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
            if(ofd.ShowDialog()==DialogResult.OK)
            {               
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap source = new Bitmap(pictureBox1.Image);
            Bitmap bmp = new Bitmap(source);
            for(int i =0;i < bmp.Height;i++)
            {
                for(int j =0;j< bmp.Width;j++)
                {
                    Color c = source.GetPixel(j, i);
                    if( c.R < 50 && c.G < 50 && c.B < 50)
                    {
                        for(int m=-1;m< 2;m++)
                        {
                            for(int n = -1;n<2;n++)
                            {
                                int vx = j + m;
                                int vy = i + n;
                                if (vx < 0 | vy < 0 | vx >= bmp.Width | vy >= bmp.Height)
                                    continue;
                                bmp.SetPixel(vx, vy, c);
                            }
                        }
                    }
                }
            }
            pictureBox1.Image = bmp;

        }
    }
}
