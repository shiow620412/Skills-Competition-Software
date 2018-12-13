using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Wind.MemoryBitmap
{
    class MemoryBitmap
    {
        public Bitmap bmp;

        private byte[] b;
        public int Width;
        public int Height;
        private int depth;
        public MemoryBitmap(Bitmap bmp)
        {
            this.bmp = bmp;
            Width = bmp.Width;
            Height = bmp.Height;
            depth = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            LoadMemory();
        }
        public void LoadMemory()
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            b = new byte[Width * Height * depth];
            Marshal.Copy(data.Scan0, b, 0, b.Length);
            bmp.UnlockBits(data);
        }
        public void SaveMemory()
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(b, 0, data.Scan0, b.Length);
            bmp.UnlockBits(data);
        }
        public void SetPixel(int x, int y, int R, int G, int B)
        {
            b[(y * Width + x) * depth + 2] = (byte)R;
            b[(y * Width + x) * depth + 1] = (byte)G;
            b[(y * Width + x) * depth] = (byte)B;
        }
        public Color GetPixel(int x, int y)
        {
            return Color.FromArgb(b[(y * Width + x) * depth + 2], b[(y * Width + x) * depth + 1], b[(y * Width + x) * depth]);
        }
        public void Gray()
        {
            LoadMemory();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Color c = GetPixel(i, j);
                    int val = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    SetPixel(i, j, val, val, val);
                }
            }
            SaveMemory();
        }
    }
}
