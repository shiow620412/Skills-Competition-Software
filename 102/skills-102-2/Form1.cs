using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_102_2
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
            textBox1.Text = (rnd.Next(0,10000)+Math.Round(rnd.NextDouble(), 6)).ToString(); ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text.Substring(0, textBox1.Text.IndexOf(".")));
            double dot = double.Parse("0" + textBox1.Text.Substring(textBox1.Text.IndexOf(".")));
            string ans = "";
            while( dot !=0 && ans.Length!=10)
            {
                dot *= 2;
                if(dot >=1)
                {
                    ans += "1";
                    dot -= 1;
                }
                else
                {
                    ans += "0";
                }
            }
          
            textBox2.Text = Convert.ToString(num,2)+"."+ans;
            
           for(int i =ans.Length-1;i>=0;i--)
            {
                if(  ans[i].ToString()=="1")
                {
                    if(i != ans.Length - 1)
                        ans = ans.Remove(i + 1);
                    break;
                }
            }
            textBox3.Text = Convert.ToString(num, 2) + "." + ans;
        }
    }
}
