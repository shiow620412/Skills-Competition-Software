using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬練習1_05
{
    public partial class Form1 : Form
    {
        Hashtable ht = new Hashtable();
        Button[] btn;
        public Form1()
        {
            InitializeComponent();
            btn = new Button[] { button1, button2, button3, button4, button5, button6, button7,button9 };
            btn.ToList().ForEach(x =>
            {
                x.Click += (s, e) =>
                {
                    x.BackColor = x.BackColor == Color.Gray ? Color.White : Color.Gray;
                };
            });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string s = "";
            btn.Reverse().ToList().ForEach(x =>
            {
                s += x.BackColor == Color.Gray ? "1" : "0";
            });
            label1.Text = "0x"+Convert.ToInt16(s,2).ToString("X2");
            Clipboard.SetText(label1.Text);

        }


  

   
    }
}
