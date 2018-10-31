using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_102_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<TextBox> lst = Controls.OfType<TextBox>().ToList();
            lst.ForEach(x => x.Clear());
            label3.Text = "";
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int m = int.Parse(textBox1.Text);
            int n = int.Parse(textBox2.Text);
            int ans = int.Parse(textBox3.Text);
            if (m * n == ans)
            {
                label4.Text = "Very Good!";
                label3.Text = "";
            }
            else
            {
                label4.Text = "is wrong";
                int tenM = m / 10;
                int singleM = m % 10;
                int tenN = n / 10;
                int singleN = n % 10;
                string calc = "";
                calc += $"(1) {m}+{singleN}={m + singleN}";
                calc += $"\r\n(2) {m + singleN}x10={(m + singleN) * 10}";
                calc += $"\r\n(3) {singleM}x{singleN}={singleN * singleM}";
                calc += $"\r\n(4) {(m + singleN) * 10}+{singleN * singleM}={singleN * singleM + (m + singleN) * 10}";
                label3.Text = calc;

            }
        }
    }
}
