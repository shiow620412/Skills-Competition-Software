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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Wind.MemoryBitmap;
namespace Canny算法
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
            pictureBox2.Image = gray(new Bitmap(pictureBox1.Image));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Gaussian(new Bitmap(pictureBox2.Image));
        }
        Bitmap gray(Bitmap bmp)
        {
            Bitmap gray = new Bitmap(bmp);
            for (int i = 0; i < gray.Width; i++)
            {
                for (int j = 0; j < gray.Height; j++)
                {
                    Color c = gray.GetPixel(i, j);
                    int val = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    gray.SetPixel(i, j, Color.FromArgb(val, val, val));
                }
            }
            return gray;
        }
        Bitmap Gaussian(Bitmap bmp)
        {

            Bitmap Gaussian = new Bitmap(bmp);
            //5x5模板
            int[] model = new int[] {
             1,4,7,4,1,
             4,16,26,16,4,
             7,26,41,26,7,
             4,16,26,16,4,
             1,4,7,4,1};
            byte[] b = new byte[Gaussian.Width * Gaussian.Height * 4];
            BitmapData data = Gaussian.LockBits(new Rectangle(0, 0, Gaussian.Width, Gaussian.Height), ImageLockMode.ReadWrite, Gaussian.PixelFormat);
            IntPtr ptr = data.Scan0;
            Marshal.Copy(ptr, b, 0, b.Length);
            /*
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == 77)
                    textBox1.Text += i.ToString().PadLeft(4)+" ";
            }
            */

            for (int y = 2; y < Gaussian.Height - 2; y++)
            {
                for (int x = 2; x < Gaussian.Width - 2; x++)
                {
                    int sum = 0;
                    int index = 0;
                    for (int m = y - 2; m < y + 3; m++)
                    {
                        for (int n = x - 2; n < x + 3; n++)
                        {
                            sum += b[m * Gaussian.Width * 4 + n * 4] * model[index++];
                            //sum += Gaussian.GetPixel(n, m).R * model[index++];
                        }
                    }
                    sum /= 273;
                    sum = sum > 255 ? 255 : sum;
                    //Gaussian.SetPixel(x, y, Color.FromArgb(sum, sum, sum));
                    b[y * Gaussian.Width * 4 + x * 4] = (byte)sum;
                    b[y * Gaussian.Width * 4 + x * 4 + 1] = (byte)sum;
                    b[y * Gaussian.Width * 4 + x * 4 + 2] = (byte)sum;
                }
            }

            Marshal.Copy(b, 0, ptr, b.Length);
            Gaussian.UnlockBits(data);
            return Gaussian;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox3.Image);
            Sobel[,] sb = new Sobel[bmp.Width , bmp.Height ];
            int depth = Image.GetPixelFormatSize(bmp.PixelFormat)/8;
            byte[] b = bmp.GetBytes();
            for (int y = 1; y < bmp.Height-1; y++)
            {
                for (int x = 1; x < bmp.Width-1; x++)
                {
                    sb[x,y] = new Sobel(x, y, b,bmp.Width,depth);
                }
            }
            float leftPixel=0, rightPixel=0;
           
   
            float maxGradient = 0;            
            for(int i =0;i<bmp.Width;i++)
                for(int j =0;j<bmp.Height;j++)
                {
                    if (sb[i, j] == null)
                        sb[i, j] = new Sobel();
                    if ( maxGradient < sb[i, j].gradient)
                        maxGradient = sb[i, j].gradient;
                    
                }
            for (int y = 1; y < bmp.Height - 1; y++)            
                for (int x = 1; x < bmp.Width - 1; x++)
                {
                    switch(sb[x,y].orient)
                    {
                        case 0:
                            leftPixel = sb[x - 1, y].gradient;
                            rightPixel = sb[x + 1, y].gradient;
                            break;
                        case 45:
                            leftPixel = sb[x - 1, y+1].gradient;
                            rightPixel = sb[x + 1, y-1].gradient;
                            break;
                        case 90:
                            leftPixel = sb[x , y+1].gradient;
                            rightPixel = sb[x, y-1].gradient;
                            break;
                        case 135:
                            leftPixel = sb[x - 1, y-1].gradient;
                            rightPixel = sb[x + 1, y+1].gradient;
                            break;
                    }
                    if (sb[x, y].gradient < leftPixel || sb[x, y].gradient < rightPixel)                                           
                      BmpSetPoint(ref b, (y*bmp.Width+x)*depth,0);                    
                                 
                    
                }
           


           
            byte highThreshold =byte.Parse(textBox1.Text);
            byte lowThreshold = byte.Parse(textBox2.Text);
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {

                    if (sb[x, y].gradient > highThreshold)
                        BmpSetPoint(ref b, (y * bmp.Width + x) * depth, 255);
                    else if (sb[x, y].gradient < lowThreshold)
                        BmpSetPoint(ref b, (y * bmp.Width + x) * depth, 0);
                    else
                    {
                        bool edge = true;
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                int vx = x + j;
                                int vy = y + i;
                                if (vx < 0 | vy < 0 | vx >= bmp.Width | vy >= bmp.Height)
                                    continue;
                                if (sb[vx, vy].gradient > highThreshold)
                                {
                                    edge = false;
                                    break;
                                }
                            }
                            if (!edge)
                                break;
                        }
                    }
                }
            bmp.WriteBytes(b);
            /*
            for (int i = 0; i < bmp.Width; i++)            
                for(int j=0;j<bmp.Height;j++)                
                    if(b[(j*bmp.Width+i)*depth] != 0 )                    
                        BmpSetPoint(ref b, (j * bmp.Width + i) * depth, 255);
                    */



            pictureBox4.Image = bmp;
        }
         void BmpSetPoint(ref byte[] b, int point, int color)
        {
            b[point] = (byte)color;
            b[point + 1] = (byte)color;
            b[point + 2] = (byte)color;
        }
    }
    
    static class ExtensionBitmap
    {
        public static byte[] GetBytes(this Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            byte[] b = new byte[width*height * Bitmap.GetPixelFormatSize(bmp.PixelFormat)/8];          
            Marshal.Copy(data.Scan0, b, 0, b.Length);
            bmp.UnlockBits(data);
            return b;
        }
        public static void WriteBytes(this Bitmap bmp, byte[] b)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(b, 0, data.Scan0, b.Length);
            bmp.UnlockBits(data);
        }
        
    }
   
    class Sobel
    {
        public int Gx = 0;
        public int Gy = 0;
        public float gradient;
        public byte orient;
        private int[] xModel = new int[] { 1, 0, -1, 2, 0, -2, 1, 0, -1 };
        private int[] yModel = new int[] { 1, 2, 1, 0, 0, 0, -1, -2, -1 };
        public Sobel()
        {
            gradient = 0;
            orient = 255;
        }
        public Sobel(int x, int y, byte[] b,int width,int depth)
        {
            
            int index = 0;
           
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Gx += xModel[index] * b[(y + j) * width * depth + depth * (x + i)];
                    Gy += yModel[index] * b[(y + j) * width * depth + depth * (x + i)];
                    index++;
                }
            }
            gradient = (float)Math.Sqrt(Gx * Gx + Gy * Gy);
            orient = (byte)((Math.Atan2(Gy, Gx) * Math.PI / 180 + 180) % 180);
            if (orient < 22.5)
                orient = 0;
            else if (orient < 67.5)
                orient = 45;
            else if (orient < 112.5)
                orient = 90;
            else if (orient < 157.5)
                orient = 135;
            else
                orient = 0;
            /*
            if (Gx == 0) {
                orient = (Gy == 0) ? (byte)0 : (byte)90;
            }
            else
            {
                double div = (double)Gy / Gx;
                if (div < 0) {
                    orient = (byte)(180 - Math.Atan(-div) * 180 / Math.PI);
                } else {
                    orient = (byte)(Math.Atan(div) * 180 / Math.PI);
                } //只保留成4個方向 
                if (orient < 22.5)
                    orient = 0;
                else if (orient < 67.5)
                    orient = 45;
                else if (orient < 112.5)
                    orient = 90;
                else if (orient < 157.5)
                    orient = 135;
                else
                    orient = 0;
            }*/

        }


    }
}

