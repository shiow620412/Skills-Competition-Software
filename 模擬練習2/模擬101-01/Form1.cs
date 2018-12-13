using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬101_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c, d;
            int.TryParse(textBox1.Text.PadLeft(2).Substring(0, 1), out a);
            int.TryParse(textBox1.Text.PadLeft(2).Substring(1, 1), out b);
            int.TryParse(textBox2.Text.PadLeft(2).Substring(0, 1), out c);
            int.TryParse(textBox2.Text.PadLeft(2).Substring(1, 1), out d);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.TranslateTransform(200, 200);
            
            Pen line = new Pen(Color.Red);
            line.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int i = 1; i <= a; i++)
                    g.DrawLine(Pens.Red, i * 10, -200, -200, i * 10);
            if(a==0)
                g.DrawLine(line,  10, -200, -200,  10);
            for (int i = 1; i <= b; i++)             
                    g.DrawLine(Pens.Red, 200, -i * 10, -i * 10, 200);
           if(b==0)
                g.DrawLine(line, 200, -10, -10, 200);
            line.Color = Color.Blue;
            for (int i = 1; i <= c; i++)                
                    g.DrawLine(Pens.Blue, -200, -i * 10, i * 10, 200);
            if(c==0)
                    g.DrawLine(line,  -200, -10, 10,  200);
            for (int i = 1; i <= d; i++)
                    g.DrawLine(Pens.Blue, -i * 10, -200, 200, i * 10);
            if(d==0)
                    g.DrawLine(line, -10, -200, 200, 10);
        }
    }
}
