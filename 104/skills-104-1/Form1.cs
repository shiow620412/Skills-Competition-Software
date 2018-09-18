using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_104_1
{
    public partial class Form1 : Form
    {
        Label[,] lbls = new Label[4, 4];
        Button[] btn;
        Label lb = new Label();
        public Form1()
        {
            InitializeComponent();
            for(int i =0;i< 4;i++)
            {
                for(int j =0;j<4;j++)
                {
                    lbls[i, j] = new Label();
                    Label lbl = lbls[i, j];

                    lbl.Size = new Size(50, 20);
                    lbl.Location = new Point(10+j*100, 50+i*50);
                    lbl.BorderStyle = BorderStyle.Fixed3D;
                    lbl.Click += (s, e) =>
                    {
                        lb = ((Label)s);
                    };
                    Controls.Add(lbl);
                }
            }
            lbls[0, 0].Text = "1";
            lbls[1, 1].Text = "2";
            lbls[2,2].Text = "3";
            lbls[3, 3].Text = "4";
            btn = new Button[] { button1, button2, button3, button4 };
            for (int i = 0; i < btn.Length; i++)
                btn[i].Click += (s, e) =>
                {
                    lb.Text = ((Button)s).Text;
                };
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                if (checkLtoR(i) && checkUtoD(i))
                    continue;
                else
                {
                    MessageBox.Show("錯誤");
                    return;
                }
            for (int i = 0; i <= 2; i += 2)
                for (int j = 0; j <= 2; j += 2)
                    if (checkblock(i, j))
                        continue;
                     else
                    {
                        MessageBox.Show("錯誤");
                        return;
                    }
            MessageBox.Show("正確");

        }
        bool checkblock(int x ,int y)        
        {
            bool[] check = new bool[5];
            int val = 0;
            if (x % 2 == 1)
                x -= 1;
            if (y % 2 == 1)
                y -= 1;
            for(int i = x;i<=x+1;i++)
            {
                for(int j=y; j<=y+1;j++)
                {
                    val++;
                    int.TryParse(lbls[i, j].Text, out val);
                    check[val] = true;
                    point[val] = true;
                }
            }
            if (check.ToList().Count(ck => ck == true) != 4)
                return false;
            else
                return true;
        }
        bool checkLtoR(int index)
        {
            bool[] check = new bool[5];
            
            check = new bool[5];
            for (int j = 0; j < 4; j++)
            {
                int ind;
                int.TryParse(lbls[index, j].Text, out ind);
                check[ind] = true;
                point[ind] = true;
            }
            if (check.ToList().Count(x => x == true) != 4)
                return false;
            else
                return true;
            
        }
        bool checkUtoD(int index)
        {
            bool[] check = new bool[5];

            check = new bool[5];
            for (int j = 0; j < 4; j++)
            {
                int ind;
                int.TryParse(lbls[j, index].Text, out ind);
                check[ind] = true;
                point[ind] = true;
            }
            if (check.ToList().Count(x => x == true) != 4)
                return false;
            else
                return true;

        }
        bool[] point = new bool[5];
        private void button6_Click(object sender, EventArgs e)
        {
            point = new bool[5];
            for(int i =0;i<4;i++)
            {
                for(int j =0;j<4;j++)
                {
                    if(lbls[i,j].Text.Length !=1)
                    {
                        lbls[i, j].Text = "";
                        point = new bool[5];
                        checkLtoR(i);
                        checkUtoD(j);
                        checkblock(i, j);
                        for (int k = 1; k < point.Length; k++)
                            if (!point[k])
                                lbls[i, j].Text += "," + k;
                        if(lbls[i,j].Text.Length >1)
                            lbls[i, j].Text = lbls[i, j].Text.Substring(1);
                    }
                }
            }
        }
    }
}
