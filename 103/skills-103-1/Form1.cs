using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_103_1
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
            textBox7.Clear();
            float x = float.Parse(textBox1.Text);
            float y = float.Parse(textBox2.Text);
            float z = float.Parse(textBox3.Text);
            float a = float.Parse(textBox4.Text);
            float b = float.Parse(textBox5.Text);
            float c = float.Parse(textBox6.Text);
            textBox7.Text = $"在台北市的上班族遲到的機率為:{x*a+y*b+z*c}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            float x = float.Parse(textBox1.Text);
            float y = float.Parse(textBox2.Text);
            float z = float.Parse(textBox3.Text);
            float a = float.Parse(textBox4.Text);
            float b = float.Parse(textBox5.Text);
            float c = float.Parse(textBox6.Text);
            float late = x * a + y * b + z * c;
            late =  (c*z) / late;
            textBox7.Text = $"如果已知有一個人上班遲到，那他是自己開車的機率為何 :{late} ";
        }
    }
}
