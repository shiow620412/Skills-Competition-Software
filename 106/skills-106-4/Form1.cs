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
namespace skills_106_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text=File.ReadAllText(ofd.FileName);
            }
            
        }

        double n;
        
        Weights weight = new Weights();
        private void button1_Click(object sender, EventArgs e)
        {
            n = double.Parse(textBox3.Text);
            Cmd[] cmd = new Cmd[3];
            weight.w = Array.ConvertAll(textBox4.Text.Split(';'), double.Parse);
            bool first = true;
            while(weight.Error >0 | first)
            {
                weight.Error = 0;
                first = false;
                for (int i = 0; i < cmd.Length; i++)
                {
                    string[] input = textBox1.Text.Replace("\r", "").Split('\n')[i].Split('\t');
                    cmd[i] = new Cmd(Array.ConvertAll(input, double.Parse), weight);
                    if (cmd[i].y != cmd[i].sign)
                        weight.updateW(cmd[i], n);
                    weight.Error = weight.Error + 0.5 * Math.Pow(cmd[i].y - cmd[i].sign, 2);
                }
              
            }
            textBox5.Text = string.Join(";", weight.w);
           
        }
        class Cmd
        {
            public double[] x= new double[3];
            public double y;
            public double sign;
            public Cmd(double[] d,Weights W)
            {
                for(int i = 0;i<d.Length;i++)
                {
                    if (i < d.Length - 1)
                    {
                        sign += W.w[i] * d[i];
                        x[i] = d[i];
                    }
                    else if(d.Length==4)
                        y = d[d.Length - 1];
                }
                
                sign = LorR(sign);
            }
            public double LorR(double f)
            {
                if (f >= 0)
                    return 1;
                else
                    return -1;
            }
        }
        class Weights
        {
            public double[] w = new double[3];
            public double Error;
            public void updateW(Cmd c,double n)
            {
                for(int i = 0; i <w.Length;i++)
                {
                    w[i] = w[i] + n * (c.y - c.sign) * c.x[i];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cmd cmd;            
            double[] inputCMD =Array.ConvertAll(textBox6.Text.Split(';'),double.Parse);
            cmd = new Cmd(inputCMD, weight);
            string s = (cmd.sign == 1) ? "左" : "右";       
            label10.Text = $"機器人向:{cmd.sign}( { s })";


        }
    }
}
