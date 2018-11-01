using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_101_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text[0].ToString());
            int b = int.Parse(textBox1.Text[1].ToString());
            int c = int.Parse(textBox2.Text[0].ToString());
            int d = int.Parse(textBox2.Text[1].ToString());
            
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.TranslateTransform(180, 180);
                  
           
                
            for(int i = 1;i<=a;i++)
            {
                g.DrawLine(Pens.Red, -180,i*10 ,i*10, -180);
            }
            for (int i = 1; i <= b; i++)
            {
                g.DrawLine(Pens.Red, 180, -i * 10 , -i * 10 , 180);
            }
            for (int i = 1; i <= d; i++)
            {
                g.DrawLine(Pens.Blue, 180, i * 10, -i * 10, -180);
            }
            for (int i = 1; i <= c; i++)
            {
                g.DrawLine(Pens.Blue, -180, -i * 10, i * 10, 180);
            }
            Pen p = new Pen(Color.Red);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            if (a==0)
            {
                g.DrawLine(p, -180,  10,  10, -180);
            }
            else if(b==0)
            {
                g.DrawLine(p, 180, -10, -10, 180);
            }
            else if(c==0)
            {
                p.Color = Color.Blue;
                g.DrawLine(p, -180,  10, 10, 180);
            }
            else if (d==0)
            {
                p.Color = Color.Blue;
                g.DrawLine(p, 180,  10, -10, -180);
            }
        }
    }
}
