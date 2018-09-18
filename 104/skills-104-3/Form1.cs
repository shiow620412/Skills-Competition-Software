using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace skills_104_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int i = rnd.Next(-127, 129);
            if (i < 0)
                textBox1.Text = "1";
            else
                textBox1.Text = "0";
            i = Math.Abs(i + 127);
            textBox2.Text = Convert.ToString(i, 2).PadLeft(8,'0');
            textBox3.Clear();
            while (textBox3.Text.Length != 23)
                textBox3.Text += rnd.Next(0, 2);
            textBox4.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            textBox4.Text = (textBox1.Text == "1") ? "-" : "";
            int E1 = Convert.ToInt16(textBox2.Text, 2)-127;
            double E = Math.Pow(2, double.Parse(E1.ToString()));
            string val = "1." + textBox3.Text;
          
          //  float M = Convert.ToInt32(val.TrimEnd('0'),2);
            double ans = E * getDot(val);
            ans = Math.Floor(ans* 100000000)/ 100000000;
            textBox4.Text += ans;
        }
        double getDot(string str)
        {
            double dot = 0;
            str = str.TrimEnd('0');
            str = str.Replace(".", "");
            List<double> test = new List<double>();
            for(int i =0;i<str.Length;i++)
            {
                double val =   double.Parse(str[i].ToString());
                if(val !=0)
                dot += Math.Pow(2, -i*val);
                
            }
            return dot;
        }
    }
}
