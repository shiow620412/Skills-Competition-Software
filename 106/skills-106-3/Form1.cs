using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_106_3
{
    
    public partial class Form1 : Form
    {
        Button[] btns;
        bool[] on;
        public Form1()
        {
            InitializeComponent();
            btns = new Button[7]
            {
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7
            };
            btns.ToList().ForEach(x =>
            {
                x.Click += (s, e) =>
                {
                    Button btn = ((Button)s);
                    if (btn.BackColor == Color.White)
                        btn.BackColor = Color.Red;
                    else
                        btn.BackColor = Color.White;
                };
            });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            on = new bool[7];
            for (int i = 0;i<on.Length;i++)
            {
                if (btns[i].BackColor == Color.Red)
                    on[i] = true;
            }
            textBox1.Text = num(on);
        }
        string num(bool[] on)
        {
            int countOn = on.ToList().Count(x => x == true);
            if (  countOn == 6 && !on[6])            
                return "0";
            if (countOn == 2 && (on[1] && on[2] ))
                return "1";
            if (countOn == 2 && (on[4] && on[5]))
                return "1";
            if (countOn == 5 && !on[2] && !on[5])
                return "2";
            if (countOn == 5 && !on[4] && !on[5])
                return "3";
            if (countOn == 4 && !on[0] && !on[3] && !on[4])
                return "4";
            if (countOn == 5 && !on[1] && !on[4])
                return "5";
            if (countOn == 6 && !on[1] )
                return "6";
            if (countOn == 3 && on[0] && on[1] && on[2])
                return "7";
            if (countOn == 7)
                return "8";
            if (countOn == 6 && !on[4])
                return "9";
            if (countOn == 5 && !on[4] && !on[3])
                return "9";

            return "非數字";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for(int i =0; i <btns.Length;i++)
            {
                if (rnd.Next(0, 2) == 1)
                    btns[i].BackColor = Color.Red;
                else
                    btns[i].BackColor = Color.White;
            }
            on = new bool[7];
            for (int i = 0; i < on.Length; i++)
            {
                if (btns[i].BackColor == Color.Red)
                    on[i] = true;
            }
            textBox1.Text = num(on);
        }
    }
}
