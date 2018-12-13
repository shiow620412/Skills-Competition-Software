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
namespace 北軟106_3自動比例
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(1600, 880);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            pictureBox1.Image = bmp;

            pictureBox2.Parent = pictureBox1;
           pictureBox2.Location = pictureBox1.Location;
           pictureBox2.Size = pictureBox1.Size;
            Bitmap line = new Bitmap(1600, 880);
             g = Graphics.FromImage(line);
            for (int i = 0; i < line.Width; i++)
                if(i%5==0)
                g.DrawLine(Pens.Gray, i, 0, i, line.Height - 1);
            for (int i = 0; i < line.Height; i++)
                if (i % 5 == 0)
                    g.DrawLine(Pens.Gray, 0, i, line.Width-1, i);
            pictureBox2.Image = line;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p == null)
                return;
            List<Point> ls = new List<Point>();
            for (int i = 0; i <= p.Max(item => item.X); i++)
            //for(int i = (int)p.Min(item=>item.X);i<= p.Max(item=>item.X);i++)
            //for (int i = 0; i <bmp.Width; i++)
            {

                float y = 0;
                for (int j = 0; j < p.Count; j++)
                {
                    float up = 1;
                    float down = 1;
                    for (int k = 0; k < p.Count; k++)
                    {
                        if (j == k)
                            continue;
                        up *= i - p[k].X;
                        down *= p[j].X- p[k].X;
                    }
                    y += p[j].Y * up / down;
                }
                ls.Add(new Point(i, (int)y));
            }
            bmp = new Bitmap(ls.Max(item => item.X), ls.Max(item => item.Y) > 880 ? 880 : ls.Max(item => item.Y));
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].X >= bmp.Width | p[i].Y >= bmp.Height)
                    continue;
                bmp.SetPixel((int)p[i].X, (int)p[i].Y, Color.Red);
            }
            
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
            g.DrawLines(Pens.Red, ls.ToArray());
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        
        }
        List<PointF> p = new List<PointF>();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                p.Clear();
                string[] input = File.ReadAllLines(ofd.FileName);
                float[] val;
                bmp = new Bitmap(1600, 880);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                             
                g.Clear(Color.White);
                for(int i = 0;i<input.Length;i++)
                {
                    val = Array.ConvertAll(input[i].Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries), float.Parse);
                    p.Add(new PointF(val[0], val[1]));                                    
                    if (p[i].X >= bmp.Width | p[i].Y >= bmp.Height)
                        continue;
                    bmp.SetPixel((int)p[i].X, (int)p[i].Y, Color.Red);
                }

                pictureBox1.Image = bmp;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Visible = !pictureBox2.Visible;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"{e.X},{e.Y}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(1600, 880);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
            p.Clear();
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            p.Add(new PointF(e.X,e.Y));
            bmp.SetPixel(e.X, e.Y, Color.Red);
            pictureBox1.Refresh();
        }
    }
}
