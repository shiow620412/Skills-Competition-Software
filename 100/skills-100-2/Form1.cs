using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_100_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] input = Array.ConvertAll(textBox1.Text.Split(new string[] { ".", "/" }, StringSplitOptions.RemoveEmptyEntries),int.Parse);
            //可用IP數
            textBox4.Text = (Math.Pow(2, 32 - input[4]) - 2).ToString();
            string[] s = new string[4];
            for (int i = 0; i < 4; i++)
                s[i] = Convert.ToString(input[i], 2).PadLeft(8, '0');

            int[] network = new int[4];
            string str = string.Join("", s).Substring(0, input[4]).PadRight(32, '0');
            for(int i=0;i<4;i++)
            {
                network[i] = Convert.ToInt16(str.Substring(i * 8, 8),2);                
            }
            textBox2.Text = string.Join(".", Array.ConvertAll(network, x=>x.ToString()));

            str = string.Join("", s).Substring(0, input[4]).PadRight(32, '1');
            int[] broadcast = new int[4];
            for (int i = 0; i < 4; i++)
            {
                broadcast[i] = Convert.ToInt16(str.Substring(i * 8, 8), 2);
            }
            textBox3.Text = string.Join(".", Array.ConvertAll(broadcast, x => x.ToString()));


        }
    }
}
