using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_105_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<TextBox> t = Controls.OfType<TextBox>().ToList();
            t.ForEach(x => x.Clear());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] num = new string[]
            {
                "0","1","2","3","4","5","6","7","8","9",
                "A","B","C","D","F","G","H","I","J"
            };
            //可用以下式子取代上方陣列
            // Convert.ToChar(65+NUM-10 ) 
            Stack<string> output = new Stack<string>();
            int input = int.Parse(textBox1.Text);
            int baseNum = int.Parse(textBox2.Text);
            while( input !=0)
            {
                int mod = Math.Abs(input % baseNum);
                if (input < 0 && Math.Abs(input) < Math.Abs(baseNum))
                {
                    mod = input - baseNum;
                }
                input = (input - mod) / baseNum;
                output.Push(num[mod]);
            }
           // output.Push(num[Math.Abs(input)]);
            textBox3.Clear();
            while (output.Count > 0)
                textBox3.Text += output.Pop();
        }
    }
}
