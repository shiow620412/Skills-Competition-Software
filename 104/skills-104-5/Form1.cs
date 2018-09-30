using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_104_5
{
    public partial class Form1 : Form
    {
        TextBox[,] I = new TextBox[7, 7];
        TextBox[,] K = new TextBox[3, 3];
        TextBox[,] O = new TextBox[7, 7];

        public Form1()
        {
            InitializeComponent();
            TextBox txt = new TextBox();
            for(int i = 0; i < 7;i++)
            {
                for(int j = 0;j<7;j++)
                {
                    txt = I[j, i] = new TextBox();
                    txt.Text = "0";
                    txt.Location = new Point(0 + j * 30, 0 + i * 30);
                    txt.Size = new Size(20, 25);
                    if (j > 1 && j < 5 && i > 1 && i < 5)
                        txt.BackColor = Color.Pink;
                    Controls.Add(txt);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    txt = K[j, i] = new TextBox();
                    txt.Text = "0";
                    txt.Location = new Point(240 + j * 30, 0 + i * 30);
                    txt.Size = new Size(20, 25);
                    if (i == 1 && j == 1)
                        txt.BackColor = Color.Pink;
                    Controls.Add(txt);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    txt = O[j, i] = new TextBox();
                    txt.Text = "0";
                    txt.Location = new Point(360 + j * 30, 0 + i * 30);
                    txt.Size = new Size(20, 25);
                    if (j > 1 && j < 5 && i > 1 && i < 5)
                        txt.BackColor = Color.Pink;
                    Controls.Add(txt);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] flipped = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    flipped[j, i] = int.Parse(K[j, i].Text);
            for(int i =0; i< 3; i++)
            {
                int temp = flipped[i, 2];
                flipped[i, 2] = flipped[i, 0];
                flipped[i, 0] = temp;
            }
            for (int i = 0; i < 3; i++)
            {
                int temp = flipped[0, i];
                flipped[0, i] = flipped[2, i];
                flipped[2, i] = temp;
            }
            int[,] arr = new int[3, 3];
            for(int i= 0; i < 7;i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    
                    for(int m= -1;m<=1;m++)
                    {
                        for(int n =-1;n<=1;n++)
                        {
                            if (j + n < 0 | i + m < 0 | j + n > 6 | i + m > 6)
                                continue;
                            int vx = j + n;
                            int vy = i + m;
                            arr[n +1, m + 1] = int.Parse(I[vx, vy].Text);
                        }
                    }

                    int ans = 0;
                    for (int m = 0; m <3; m++)
                    {
                        for (int n = 0; n <3; n++)
                        {
                            ans += arr[n, m] * flipped[n, m];
                        }
                    }
                    O[j, i].Text = ans.ToString();
                }
            }
            double MSE = 0;
            double MAE = 0;
            for(int i =0;i< 7; i++)
                for(int j =0;j<7;j++)
                {
                    float temp = int.Parse(I[j, i].Text) - int.Parse(O[j, i].Text);
                    MAE += Math.Abs(temp);
                    MSE += temp * temp;
                }
            MSE /= 49;
            MAE /= 49;
            double PSNR = 10 * Math.Log10(255 * 255 /MSE);
            textBox1.Text = MSE.ToString();
            textBox2.Text = MAE.ToString();
            textBox3.Text = PSNR.ToString();
        }
    }
}
