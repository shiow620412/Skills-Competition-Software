using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬練習1_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] group1 = Array.ConvertAll(textBox1.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int[] group2 = Array.ConvertAll(textBox2.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int[,] distance = new int[group1.Length+1, group2.Length+1];            
            for (int x = 0; x < group1.Length; x++)            
               distance[x + 1, 0] = group1[x];            
            for (int y = 0; y < group2.Length; y++)           
                distance[0, y + 1] = group2[y];                        
            for (int y = 0; y < group2.Length; y++)
            {
                for (int x = 0; x < group1.Length; x++)
                {
                    if (x == 0 && y == 0)
                        distance[x + 1, y + 1] = Math.Abs(group1[x] - group2[y]);
                    else if (x == 0 & y > 0)
                        distance[x + 1, y + 1] = Math.Abs(group1[x] - group2[y]) + distance[1, y];
                    else if (x > 0 & y == 0)
                        distance[x + 1, y + 1] = Math.Abs(group1[x] - group2[y]) + distance[x, 1];
                    else
                        distance[x + 1, y + 1] = Math.Abs(group1[x] - group2[y]) + getMin(distance[x,y],distance[x,y+1],distance[x+1,y]);
                }
            }
            string s = "";
            for (int y = 0; y < distance.GetLength(1); y++)
            {
                for (int x = 0; x < distance.GetLength(0); x++)
                {
                    s += distance[x, y].ToString().PadLeft(2) + "\t";
                }
                s += "\r\n";
            }
            textBox3.Text = s;
        }
        int getMin(int a ,int b ,int c)
        {
            int min = int.MaxValue;
            if (min > a) min = a;
            if (min > b) min = b;
            if (min > c) min = c;
            return min;
        }
    }
}
