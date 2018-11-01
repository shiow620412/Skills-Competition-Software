using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_101_5
{
    public partial class Form1 : Form
    {
        TextBox[,] txt = new TextBox[3, 3];
        bool[] book = new bool[9];
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            for(int i =0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    txt[j, i] = new TextBox();
                    txt[j, i].Location = new Point(10 + j * 50, 10 + i * 50);
                    txt[j, i].Size = new Size(30, 50);
                    if(i==1 && j==1)
                    {
                        txt[j, i].Text = "";
                        Controls.Add(txt[j, i]);
                        continue;
                    }
                    int val = rnd.Next(1, 9);
                    while(book[val]==true)
                    {
                        val = rnd.Next(1, 9);
                    }
                    book[val] = true;
                    txt[j, i].Text = val.ToString();
                    Controls.Add(txt[j, i]);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 1; i < 9; i++) book[i] = false;
            for(int i =0;i<3;i++)
                for(int j=0;j<3;j++)
                {
                    if (j == 1 && i == 1) continue;
                    int val = rnd.Next(1, 9);
                    while (book[val] == true) val = rnd.Next(1, 9);
                    book[val] = true;
                    txt[j, i].Text = val.ToString();
                }
        }
        Queue<Point> queue = new Queue<Point>();
        private void button2_Click(object sender, EventArgs e)
        {
            bfs(txt,new Point(1, 1)); 
        }
        void bfs(TextBox[,] txtbox, Point p)
        {
            Point pt = new Point(-1, -1);
            string state = "";
            for (int i = 0; i < 3; i++)
            { 
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1) continue;
                    if (txt[j, i].Text == "1")
                    {
                        pt.X = j; pt.Y = i;
                        break;
                    }
                }
                if (pt.X != -1 && pt.Y != -1)
                    break;
             }
          
            while(pt.X != -1 && pt.Y!=-1 && state.Length != 8)
            {
                while(p.Y ==0)
                {

                }
            }
            while (queue.Count>0)
            {

            }
        }
    }
}
