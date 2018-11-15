using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_100_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float leftLimit = float.Parse(textBox1.Text);
            float rightLimit = float.Parse(textBox2.Text);
            string input = textBox3.Text;
            if(input.IndexOf(".") != -1)
            {
                int len = (int)(rightLimit - leftLimit) * (int)Math.Pow(10, int.Parse(textBox4.Text));
                int byteLen = 0;
                while(len > 0) { len /= 2; byteLen++; }
                float value = (float.Parse(input) - leftLimit) * (int)(Math.Pow(2, byteLen) - 1) / (rightLimit - leftLimit);
                int ans = (int)Math.Round(value);
                label5.Text = $"Ans = {Convert.ToString(ans, 2)}";
            }
            else
            {
                int value = Convert.ToInt32(input, 2);
                double ans = leftLimit + value * (rightLimit - leftLimit) / (Math.Pow(2, input.Length) - 1);
                label5.Text = $"Ans = {Math.Round(ans,int.Parse(textBox4.Text))}";
                //label5.Text = $"Ans = {ans}";
                
            }
        }
    }
}
