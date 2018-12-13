using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬練習03_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label1.Text = "CRC = 0000";
                return;
            }
            int G = 34943;
            string s = "";
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                s += Convert.ToString(textBox1.Text[i], 2).PadLeft(8, '0');
            }

            s += "".PadRight(16, '0');
            int val = 0;
            for(int i =0;i<s.Length;i++)
            {
                val <<= 1;
                val += int.Parse(s[i].ToString());
                if (val >= G)
                    val -= G;
            }
            label1.Text =$"CRC = {(G-val).ToString("X2")}";


        }
    }
}
