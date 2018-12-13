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
namespace 模擬練習1_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap gray;
        float scale;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                Bitmap source = new Bitmap(ofd.FileName);
                pictureBox1.Image = source;
                gray = new Bitmap(source.Width, source.Height);
                
                for (int x = 0; x < source.Width; x++)
                {
                    for (int y = 0; y < source.Height; y++)
                    {
                        Color c = source.GetPixel(x, y);
                        int grayColor = (int)(c.R * 0.3 + c.G * 0.59 + c.G * 0.11);
                        gray.SetPixel(x, y, Color.FromArgb(grayColor, grayColor, grayColor));
                        
                    }

                }
               
             
                int min = int.MaxValue;
                int max = 0;
                for (int y = 0; y < source.Height; y++)
                {
                    for (int x = 0; x < 50; x++)
                    {
                        int val = gray.GetPixel(x, y).R;
                        if( val < 201 )
                        {
                            min = y;
                            break;
                        }
                    }
                    if (min != int.MaxValue)
                        break;
                }
                for (int y = source.Height-1; y >=0; y--)
                {
                    for (int x = 0; x < 50; x++)
                    {
                        int val = gray.GetPixel(x, y).R;
                        if (val < 201)
                        {
                            max = y;
                            break;
                        }
                    }
                    if (max != 0)
                        break;
                }
                scale = 830f / (max - min);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int min = int.MaxValue;
            int max = 0;
            for (int y = 0; y < gray.Height; y++)
            {
                for (int x = 144; x < gray.Width; x++)
                {
                    int val = gray.GetPixel(x, y).R;
                    if (val < 201)
                    {
                        min = y;
                        break;
                    }
                }
                if (min != int.MaxValue)
                    break;
            }
            for (int y = gray.Height - 1; y >= 0; y--)
            {
                for (int x = 144; x < gray.Width; x++)
                {
                    int val = gray.GetPixel(x, y).R;
                    if (val < 201)
                    {
                        max = y;
                        break;
                    }
                }
                if (max != 0)
                    break;
            }
            textBox1.Text = (scale * (max - min)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int min = int.MaxValue;
            int max = 0;
            for (int y = 0; y < gray.Height; y++)
            {                
                for (int x = 144; x < gray.Width; x++)
                {
                    int val = gray.GetPixel(x, y).R;
                    if (val < 201 && min > x)
                    {
                        min = x;
                        break;
                    }
                }
                
            }
            for (int y = gray.Height - 1; y >= 0; y--)
            {
                for (int x = gray.Width-1; x >=0; x--)
                {
                    int val = gray.GetPixel(x, y).R;
                    if (val < 201 && max < x)
                    {
                        max = x;
                        break ;
                    }
                }
              
            }
            textBox2.Text = (scale * (max - min)).ToString();
        }
    }
}
