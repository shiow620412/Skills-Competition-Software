using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_102_1
{
    public partial class Form1 : Form
    {
        TextBox[,] data = new TextBox[6, 6];
        TextBox[,] mask = new TextBox[3, 3];
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 6;i++)
            {
                for(int j=0;j<6;j++)
                {
                    data[j, i] = new TextBox();
                    TextBox txt = data[j, i];
                    txt.Size = new Size(30, 30);
                    txt.Location = new Point(10+j*40,40+i*40);
                    Controls.Add(txt);
                }
            }
            for(int i=0;i<3;i++)
            {
                for(int j =0;j<3;j++)
                {
                    mask[j, i] = new TextBox();
                    TextBox txt = mask[j, i];                   
                    txt.Size = new Size(30, 30);
                    txt.Location = new Point(260 + j * 40, 40 + i * 40);
                    Controls.Add(txt);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Point mid = new Point(x+1, y+1);
            int[,] input = new int[3, 3];
            int countX = -1;
            int countY = -1;
            int ans = 0;
            for(int i = y;i<=y+2;i++)
            {
                countY++;
                for(int j = x;j<=x+2;j++)
                {
                    countX++;
                    if (j == x + 1 && i == y + 1)
                        continue;
                    input[countX, countY] = ((int.Parse(data[j, i].Text) - int.Parse(data[x + 1, y + 1].Text))>=0 ? 1 : 0)* int.Parse(mask[countX,countY].Text);
                    ans += input[countX, countY];
                }
                countX = -1;
            }           
            ans += int.Parse(mask[1, 1].Text);
            txtbox_ans.Text = ans.ToString();
        }
    }
}
