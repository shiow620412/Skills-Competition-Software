using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_102_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count = 0;
        TextBox[,] txt;
        Label[] lbl;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(((TextBox)sender).Text, out count))
                return;
            if(count <3 | count >10)
            {
                flowLayoutPanel1.Controls.Clear();
                return;
            }
            count ++;
            lbl = new Label[count];
            txt = new TextBox[count, 2];
            flowLayoutPanel1.Controls.Clear();
            for(int i =1;i<count;i++)
            {
                lbl[i] = new Label();
                lbl[i].Location = new Point(12, 40+i*10);
                lbl[i].Text = $"m{i}的矩陣大小:";
                txt[i, 0] = new TextBox();
                txt[i, 0].Location = new Point(40, 20 + i * 20);
                txt[i, 0].Size = new Size(30, 20);
                txt[i, 1] = new TextBox();
                txt[i, 1].Location = new Point(80, 20 + i * 20);
                txt[i, 1].Size = new Size(30, 20);
                flowLayoutPanel1.Controls.Add(lbl[i]);
                flowLayoutPanel1.Controls.Add(txt[i, 0]);
                flowLayoutPanel1.Controls.Add(txt[i, 1]);              
            }
        }
        Point[] p;
        bool[] book;
        private void button1_Click(object sender, EventArgs e)
        {
            p = new Point[txt.GetUpperBound(0)+1];
            book = new bool[p.Length];
            for (int i = 1;  i < p.Length;i++)
            {
                p[i] = new Point(int.Parse(txt[i, 0].Text), int.Parse(txt[i, 1].Text));
                book[i] = false;
            }
            min = 2147483647;
            
            for (int i=1;i<p.Length;i++)
            {
                record.Clear();
                book[i] = true;
                record.Add(i);
                dfs(1, p[i], 0);
                book[i] = false;
             
            }
            label5.Text = min.ToString();
        }
        List<int> record = new List<int>();
        int min = 0;
        void dfs(int step,Point pt,int times)
        {
            if (step == p.GetUpperBound(0) )
            {
                if (min > times)
                {
                    min = times;
                    string s = $"m{record[0]}";
                    for(int i = 1;i<step;i++)
                    {
                        s = $"<{s} m{record[i]}> ";
                    }
                    label4.Text = s;
                }
                return;
            }
            for(int i =1;i<p.Length;i++)
            {
                if (book[i] == true)
                    continue;
                if( pt.Y == p[i].X)
                {
                    book[i] = true;
                    record.Add(i);
                    dfs(step+1, new Point(pt.X, p[i].Y), times+pt.X * pt.Y * p[i].Y);
                    record.RemoveAt(record.Count - 1);
                    book[i] = false;
                }
            }
            
        }
    }
}
