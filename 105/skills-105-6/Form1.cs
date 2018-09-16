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

namespace skills_105_6
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
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap org = new Bitmap(pictureBox1.Image);
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for(int i =0;i< org.Width; i++)
            {
                for (int j = 0; j < org.Height;j++)
                {
                    Color c = org.GetPixel(i, j);
                    string R = Convert.ToString(c.R, 2).PadLeft(8, '0')[7].ToString();
                    string G = Convert.ToString(c.G, 2).PadLeft(8, '0')[7].ToString();
                    string B = Convert.ToString(c.B, 2).PadLeft(8, '0')[7].ToString();
                    int valR = 16, valG = 16, valB = 16;
                    if (R == "0") valR = 235;
                    if (G == "0") valG = 235;
                    if (B == "0") valB = 235;
                    bmp.SetPixel(i, j, Color.FromArgb(valR, valG, valB));
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}
