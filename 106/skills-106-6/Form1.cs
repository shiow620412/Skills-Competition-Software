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

namespace skills_106_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            BigInteger bi = 1;
            for (int i = 1; i <= n; i++)
                bi *= i;
            string output = bi.ToString();
            textBox2.Text = output;
            int output2 = 0;
            for (int i = 0; i < output.Length; i++)
                output2 += int.Parse(output[i].ToString());
            textBox3.Text = output2.ToString();
            int[] book = new int[101];
            List<int> prime = new List<int>();
            prime.Add(2);
            prime.Add(3);
            prime.Add(5);
            prime.Add(7);
            for (int i = 2; i <= n;i++)
            {
                if( i %2 !=0 && i%3!=0 && i%5!=0 && i%7!=0)
                {
                    book[i]++;
                    prime.Add(i);
                    continue;
                }
                int temp = i;
                prime.ForEach(x =>
                {
                    while(temp % x == 0)
                    {
                        book[x]++;
                        temp /= x;
                    }
                });
            }
            
            textBox4.Text = book.Sum().ToString();
        }
    }
}
