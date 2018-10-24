using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_103_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] check = new int[] { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
        private void button1_Click(object sender, EventArgs e)
        {
            int Min, Max;
            int.TryParse(textBox1.Text, out Min);
            int.TryParse(textBox2.Text, out Max);
            string[] special = textBox3.Text.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            List<string> output = new List<string>();
            if( Min !=0 && Max !=0)
            for(int i = Min;i<=Max;i++ )
            {
                string str = i.ToString();
                str += check[sum(str) % 10].ToString();
                output.Add(str + "@antu.edu.tw");
            }
            special.ToList().ForEach(x =>
            {
                string str = x;
                str += check[sum(str) % 10].ToString();
                output.Add(str + "@antu.edu.tw");
            });
            textBox4.Text = string.Join(";\r\n", output.ToArray());
        }
        int sum(string s)
        {           
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sum += int.Parse(s[i].ToString()) * (i + 1);
            }
            return sum;
        }
    }
}
