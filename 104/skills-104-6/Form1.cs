using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace skills_104_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if (ofd.ShowDialog() == DialogResult.OK)
                richTextBox1.Text = File.ReadAllText(ofd.FileName,Encoding.Default); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            string input = richTextBox1.Text;
            Regex reg = new Regex(search);
            MatchCollection mc = reg.Matches(input);
            int count = 0;
            foreach(Match m in mc)
            {
                richTextBox1.Select(m.Index, m.Length);
                richTextBox1.SelectionBackColor = Color.Yellow;
                count++;
            }
            label3.Text = count.ToString();

        }
    }
}
