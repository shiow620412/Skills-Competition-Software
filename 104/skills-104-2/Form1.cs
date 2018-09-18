using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_104_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Soundex> table = new List<Soundex>();
        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
           
            table.Add(new Soundex("B", 1));
            table.Add(new Soundex("P", 1));
            table.Add(new Soundex("F", 1));
            table.Add(new Soundex("V", 1));
            table.Add(new Soundex("C", 2));
            table.Add(new Soundex("S", 2));
            table.Add(new Soundex("K", 2));
            table.Add(new Soundex("G", 2));
            table.Add(new Soundex("J", 2));
            table.Add(new Soundex("Q", 2));
            table.Add(new Soundex("X", 2));
            table.Add(new Soundex("Z", 2));
            table.Add(new Soundex("D", 3));
            table.Add(new Soundex("T", 3));
            table.Add(new Soundex("L", 4));
            table.Add(new Soundex("M", 5));
            table.Add(new Soundex("N", 5));
            table.Add(new Soundex("R", 6));

            string soundex = input[0].ToString();
            for(int i =1;i< input.Length;i++)
            {
                if(i==1 )
                {
                    if (getSoundex(input[i].ToString()) == getSoundex(soundex))
                        continue;
                }
                int val = getSoundex(input[i].ToString());
                if(val !=0)
                soundex += val ;
                if ( soundex.Length > 2 &&soundex[soundex.Length - 1] == soundex[soundex.Length - 2])
                    soundex = soundex.Substring(0, soundex.Length - 1);
            }
            if (soundex.Length > 4)
                soundex = soundex.Substring(0, 4);
            textBox2.Text = soundex.PadRight(4, '0');
        }
        int getSoundex(string s)
        {
            try
            {
                return table.Find(x => x.Alphabet == s).Code;
            }
            catch (Exception ex)
            {

            }
            return 0; 
        }
        class Soundex
        {
            public string Alphabet;
            public int Code;
            public Soundex(string Alphabet ,int Code)
            {
                this.Alphabet = Alphabet;
                this.Code = Code;
            }
        }
    }
}
