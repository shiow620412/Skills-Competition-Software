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
namespace skills_100_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            Random rnd = new Random();
            textBox1.Text = rnd.Next(16, 53).ToString();
            textBox2.Text = rnd.Next(1, 9).ToString() + "B";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int address = int.Parse(textBox1.Text);
            int bpa = int.Parse(textBox2.Text.Remove(1));
            BigInteger memory =BigInteger.Pow(2,address) * bpa;
            int level = -1;
            while( level < 3 && memory  > 1024)
            {
                memory /= 1024;
                level++;
            }
            string[] s = new string[] { "KB", "MB", "GB", "TB" };
            textBox3.Text = memory + s[level];
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            Random rnd = new Random();
            string[] s = new string[] { "KB", "MB", "GB", "TB" };
            int level = rnd.Next(0, 4);
            if (level == 3)            
                textBox4.Text = rnd.Next(1, 32769).ToString();            
            else if (level == 0)           
                textBox4.Text = rnd.Next(512, 1025).ToString();            
            else
                textBox4.Text = rnd.Next(1, 1025).ToString();
            textBox4.Text += s[level];

            textBox5.Text = rnd.Next(1, 9).ToString() + "B";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger memory=0;
            if (textBox4.Text.Contains("KB"))
                memory = BigInteger.Pow(2, 10) * int.Parse(textBox4.Text.Split('K')[0]);
            else if (textBox4.Text.Contains("MB"))
                memory = BigInteger.Pow(2, 20) * int.Parse(textBox4.Text.Split('M')[0]);
            else if (textBox4.Text.Contains("GB"))
                memory = BigInteger.Pow(2, 30) * int.Parse(textBox4.Text.Split('G')[0]);
            else if (textBox4.Text.Contains("TB"))
                memory = BigInteger.Pow(2, 40) * int.Parse(textBox4.Text.Split('T')[0]);

            int bpa = int.Parse(textBox5.Text.Remove(1));
            memory /= bpa;
            int address = 0;
            while(memory >0)
            {
                memory /= 2;
                address++;
            }
            textBox6.Text = address.ToString();
        }
    }
}
