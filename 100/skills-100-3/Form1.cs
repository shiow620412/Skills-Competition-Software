using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_100_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            time.Interval = 100;
            time.Tick += (s, e) =>
            {
                int sec = int.Parse(textBox2.Text);
                int min = int.Parse(textBox1.Text);
                if(sec -1 == -1)
                {
                   if(min == 0 )
                    {
                        time.Stop();
                        MessageBox.Show("時間到");
                    }
                   else
                    {
                        textBox1.Text = (min - 1).ToString();
                        textBox2.Text = "59";
                    }
                }
                else
                {
                    textBox2.Text = (sec - 1).ToString();
                }
            };
        }
        Timer time = new Timer();
        private void button1_Click(object sender, EventArgs e)
        {
            time.Start();
        }
    }
}
