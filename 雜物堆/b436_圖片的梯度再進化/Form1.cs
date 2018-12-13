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
namespace b436_圖片的梯度再進化
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] rectX = new int[,]
        {
            {-1,0,1 },
            {-2,0,2 },
            {-1,0,1 }
        };
        int[,] rectY = new int[,]
        {
            {-1,-2,-1 },
            {0,0,0},
            {1,2,1 }
        };
        Bitmap source;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { InitialDirectory = Directory.GetCurrentDirectory() };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                source = new Bitmap(ofd.FileName);
                Bitmap destiation = new Bitmap(source.Width, source.Height);
                source = getGray(source);
               
               /* for(int i =1;i<source.Width-1;i++)
                    for(int j =1;j <source.Height-1;j++)
                    {
                        int[] getColor = calc(i, j);
                        destiation.SetPixel(i, j, Color.FromArgb(getColor[0], getColor[1], getColor[2]));
                    }*/
                pictureBox1.Image = source;
                pictureBox2.Image = sobel(source);
            }
        }Bitmap getGray(Bitmap source)
        {
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    int gray = (int)(c.R * 0.3 + c.G * 0.59 + c.G * 0.11);
                    source.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            return source;
        }
        private static Bitmap sobel(Bitmap a)
        {
            int w = a.Width;
            int h = a.Height;
            try
            {
                Bitmap dstBitmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Imaging.BitmapData srcData = a.LockBits(new Rectangle
                    (0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Imaging.BitmapData dstData = dstBitmap.LockBits(new Rectangle
                    (0, 0, w, h), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    byte* p;
                    int stride = srcData.Stride;
                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            //边缘八个点像素不变
                            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                            {
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];

                            }
                            else
                            {
                                int r0, r1, r2, r3, r4, r5, r6, r7, r8;
                                int g1, g2, g3, g4, g5, g6, g7, g8, g0;
                                int b1, b2, b3, b4, b5, b6, b7, b8, b0;
                                double vR, vG, vB;
                                //左上
                                p = pIn - stride - 3;
                                r1 = p[2];
                                g1 = p[1];
                                b1 = p[0];
                                //正上
                                p = pIn - stride;
                                r2 = p[2];
                                g2 = p[1];
                                b2 = p[0];
                                //右上
                                p = pIn - stride + 3;
                                r3 = p[2];
                                g3 = p[1];
                                b3 = p[0];
                                //左
                                p = pIn - 3;
                                r4 = p[2];
                                g4 = p[1];
                                b4 = p[0];
                                //右
                                p = pIn + 3;
                                r5 = p[2];
                                g5 = p[1];
                                b5 = p[0];
                                //左下
                                p = pIn + stride - 3;
                                r6 = p[2];
                                g6 = p[1];
                                b6 = p[0];
                                //正下
                                p = pIn + stride;
                                r7 = p[2];
                                g7 = p[1];
                                b7 = p[0];
                                // 右下 
                                p = pIn + stride + 3;
                                r8 = p[2];
                                g8 = p[1];
                                b8 = p[0];
                                //中心点
                                p = pIn;
                                r0 = p[2];
                                g0 = p[1];
                                b0 = p[0];
                                //使用模板
                                vR = (double)(Math.Abs(r1 + 2 * r4 + r6 - r3 - 2 * r5 - r8) + Math.Abs(r1 + 2 * r2 + r3 - r6 - 2 * r7 - r8));
                                vG = (double)(Math.Abs(g1 + 2 * g4 + g6 - g3 - 2 * g5 - g8) + Math.Abs(g1 + 2 * g2 + g3 - g6 - 2 * g7 - g8));
                                vB = (double)(Math.Abs(b1 + 2 * b4 + b6 - b3 - 2 * b5 - b8) + Math.Abs(b1 + 2 * b2 + b3 - b6 - 2 * b7 - b8));
                                if (vR > 0)
                                {
                                    vR = Math.Min(255, vR);
                                }
                                else
                                {
                                    vR = Math.Max(0, vR);
                                }

                                if (vG > 0)
                                {
                                    vG = Math.Min(255, vG);
                                }
                                else
                                {
                                    vG = Math.Max(0, vG);
                                }

                                if (vB > 0)
                                {
                                    vB = Math.Min(255, vB);
                                }
                                else
                                {
                                    vB = Math.Max(0, vB);
                                }
                                pOut[0] = (byte)vB;
                                pOut[1] = (byte)vG;
                                pOut[2] = (byte)vR;

                            }
                            pIn += 3;
                            pOut += 3;
                        }
                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    }
                }
                a.UnlockBits(srcData);
                dstBitmap.UnlockBits(dstData);

                return dstBitmap;
            }
            catch
            {
                return null;
            }
        }
        int[] calc (int x,int y)
        {
            int [] temp = new int[] { 0, 0, 0 };
            int[] temp2 = new int[] { 0, 0, 0 };
            int[] ans = new int[] { 0, 0, 0 };
            for (int m = -1; m < 2; m++)
                for (int n = -1; n < 2; n++)
                {
                    int vx = x + m;
                    int vy = y + n;
                    temp[0] +=  source.GetPixel(vx, vy).R * rectX[ n+1,m+1];
                    temp[1] +=  source.GetPixel(vx, vy).G * rectX[n + 1, m + 1];
                    temp[2] +=  source.GetPixel(vx, vy).B * rectX[n + 1, m + 1];
                    temp2[0] +=  source.GetPixel(vx, vy).R * rectY[n + 1, m + 1];
                    temp2[1] +=  source.GetPixel(vx, vy).G * rectY[n + 1, m + 1];
                    temp2[2] +=  source.GetPixel(vx, vy).B * rectY[n + 1, m + 1];
                }
            int num = 0;
            for(int i=0;i<2;i++)
            {
                num = (int)Math.Sqrt( temp[i] * temp[i] + temp2[i]*temp2[i]);
                ans[i] = num>=255? 255 :num;
            }
            return ans;
        }
    }
}
