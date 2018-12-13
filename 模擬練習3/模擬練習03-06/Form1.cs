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
namespace 模擬練習03_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    int val = bmp.GetPixel(x, y).ToArgb();
                    int b = Convert.ToString(val & 0xff, 2).PadLeft(8, '0').Substring(7, 1) == "1" ? 16 : 235;
                    int g = Convert.ToString(val>>8 & 0xff, 2).PadLeft(8, '0').Substring(7, 1) == "1" ? 16 : 235;
                    int r = Convert.ToString(val>>16 & 0xff, 2).PadLeft(8, '0').Substring(7, 1) == "1" ? 16 : 235;
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { InitialDirectory = Directory.GetCurrentDirectory() };
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                button1.Enabled = true;
                button1.Text = "Reveal The Image Behind";
            }
        }
    }
}
