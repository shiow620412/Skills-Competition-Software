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
namespace skills_100_4
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
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                Bitmap source = new Bitmap(pictureBox1.Image);
                Bitmap bmp = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
                int min = Int32.MaxValue;
                int max = 0;
                int[] total = new int[256];
                for (int i = 0; i < source.Width;i++)
                    for(int j =0;j<source.Height;j++)
                    {
                        Color c = source.GetPixel(i, j);
                        int gray = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                        bmp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                        if (min > gray) min = gray;
                        if (max < gray) max = gray;
                        total[gray]++;
                    }
                int maxIndex = 0;
                float maxGrayCount = 0;
                for(int i =0;i<256;i++)
                {
                    if(maxGrayCount < total[i])
                    {
                        maxGrayCount = total[i];
                        maxIndex = i;
                    }
                }
                label1.Text = $"最小灰階為:{min}\r\n最大灰階為:{max}\r\n出現最多之灰階為:{maxIndex}\r\n最多灰階之機率為:{maxGrayCount/(bmp.Width*bmp.Height)}\r\n";
                pictureBox2.Image = bmp;

                chart1.Series.Clear();
                chart1.Series.Add("gray");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                for (int i = 0; i < 256;i++)
                {
                    if (total[i] == 0)
                        continue;
                    chart1.Series[0].Points.AddXY(i, total[i]);
                }

            }

        }
    }
}
