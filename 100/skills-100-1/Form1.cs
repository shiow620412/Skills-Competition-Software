using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_100_1
{
    public partial class Form1 : Form
    {
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            List<RadioButton> rbtn = groupBox1.Controls.OfType<RadioButton>().ToList();
            pen = new Pen(Color.Black);
            rbtn.ForEach(x => x.CheckedChanged += (s, e) =>
            {
                string str = ((RadioButton)s).Text;
                switch(str)
                {
                    case "Black":
                        pen = new Pen(Color.Black);
                        break;
                    case "Red":
                        pen = new Pen(Color.Red);
                        break;
                    case "Blue":
                        pen = new Pen(Color.Blue);
                        break;
                    case "Green":
                        pen = new Pen(Color.Green);
                        break;
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<PointF> p = new List<PointF>();
            int n = int.Parse(textBox1.Text);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            int radius = 100;
            int x = 100;
            int y = 100;
            double degree = 360 / n / 57.3;

            for(int i =1;i<= n;i++)
            {
                p.Add(new PointF( (float)(radius * Math.Cos(degree*i) + x), (float)(radius * Math.Sin(degree*i) + y)));
            }
            p.Add(p.First());
            g.DrawLines(pen, p.ToArray());
            for(int i =0; i < p.Count;i++)
            {
                p.ForEach(j =>
                {
                    g.DrawLine(pen, p[i], j);
                });
            }
        }
    }
}
