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
namespace skills_103_6
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

        private void button2_Click(object sender, EventArgs e)
        {
            List<TextBox> txt = Controls.OfType<TextBox>().ToList();
            txt.ForEach(x => x.Clear());
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger x = BigInteger.Parse(textBox1.Text);
            BigInteger p = BigInteger.Parse(textBox2.Text);
            BigInteger n = BigInteger.Parse(textBox3.Text);
            BigInteger ans = BigInteger.ModPow(x, p,n);
            label2.Text = ans.ToString();        
        }
    }
}
