using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_103_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> txt = Controls.OfType<TextBox>().ToList();
            txt.ForEach(x => x.Clear());

            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                textBox1.Text += rnd.Next(0, 2);
                textBox2.Text += rnd.Next(0, 2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] carry = new string[8];
            for (int i = 0; i < carry.Length; i++) carry[i] = "0";
            string A = textBox1.Text;
            string B = textBox2.Text;
        
            Stack<string> ans = new Stack<string>();
            for (int i = 7; i > -1; i--)
            {
                int add = int.Parse(A[i].ToString()) + int.Parse(B[i].ToString()) + int.Parse(carry[i]);
                if (add > 2)
                {
                    ans.Push("1");
                    if (i > 0)
                        carry[i - 1] = "1";
                    
                }
                else if (add >1)
                 {
                    ans.Push("0");
                    if (i > 0)
                        carry[i - 1] = "1";
                 
                }
                else
                    ans.Push(add.ToString());
            }
            textBox3.Clear();
            while (ans.Count > 0) textBox3.Text += ans.Pop();
            if( textBox1.Text [0]=='1' && textBox1.Text[0] == textBox2.Text [0] && textBox1.Text[0]!= textBox3.Text[0])
            {
                textBox4.Text = "underflow";
            }
            if (textBox1.Text[0] == '0' && textBox1.Text[0] == textBox2.Text[0] && textBox1.Text[0] != textBox3.Text[0])
            {
                textBox4.Text = "overflow";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a = new double();
            double b = new double();
            double c = new double();
            int val = 6;
            for (int i = 1; i < 8; i++)
            {
                a += (Math.Pow(2, val) * double.Parse(textBox1.Text[i].ToString()));
                b += (Math.Pow(2, val) * double.Parse(textBox2.Text[i].ToString()));
                c += (Math.Pow(2, val) * double.Parse(textBox3.Text[i].ToString()));
                val--;
            }
            if (textBox1.Text[0] == '1') a -= 128;
            if (textBox2.Text[0] == '1') b -= 128;
            if (textBox3.Text[0] == '1') c -= 128;
            textBox5.Clear(); textBox6.Clear(); textBox7.Clear();
            textBox5.Text += a.ToString();
            textBox6.Text += b.ToString();
            textBox7.Text += c.ToString();

            if (textBox4.Text == "underflow")
                textBox8.Text = "不足位";
            if (textBox4.Text == "overflow")
                textBox8.Text = "溢位";

        }
    }
}
