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
                    lbl.Location = new Point(10+i*100, 50+j*50);
                    lbl.BorderStyle = BorderStyle.Fixed3D;
                    lbl.Click += (s, e) =>
                    {
                        lb = ((Label)s);
                    };
                    Controls.Add(lbl);
                }
            }
            btn = new Button[] { button1, button2, button3, button4 };
            for (int i = 0; i < btn.Length; i++)
                btn[i].Click += (s, e) =>
                {
                    lb.Text = ((Button)s).Text;
                };
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool[] check = new bool[5];
            for (int i = 0; i < 4; i++)
            {
                check = new bool[5];
                for(int j=0;j<4;j++)
                {
                    int ind;
                    int.TryParse(lbls[i,j].Text, out ind);
                    check[ind] = true;
                }
                if(check.ToList().Count(x=>x==true) !=4)
                {
                    MessageBox.Show("錯誤");
                    return;
                }
            }
        }
    }
}
