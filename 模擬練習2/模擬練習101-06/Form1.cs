using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace 模擬練習101_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] move = new int [,] { 
            { 0, -1 },
            { 1, -1 },
            { 1, 0 },
            { 1, 1 },
            { 0, 1 },
            { -1, 1 },
            { -1, 0 },
            { -1, -1 }
        };
        int[,] map;
        bool[,] book;
        private void button1_Click(object sender, EventArgs e)
        {
            string[] input = File.ReadAllLines(textBox1.Text);
            string[] temp = input[0].Split(' ');
            map = new int[temp.Length, input.Length];
            book = new bool[temp.Length, input.Length];
            for(int i =0;i<input.Length;i++)
            {
                temp = input[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    map[j, i] = int.Parse(temp[j]);
            }
            textBox2.Text = "(0,0)";
            dfs(0, 0);
            if (!goal)
                textBox2.Text = "無出口";
        }
        bool goal = false;
        void dfs(int x ,int y)
        {
            if(x==7 && y==7)
            {
                goal = true;
                return;
            }
            for(int i=0;i<move.GetLength(0);i++)
            {
                if (goal)
                    break;
                int vx = x + move[i, 0];
                int vy = y + move[i, 1];
                if (vx < 0 | vy < 0 | vx >= map.GetLength(0) | vy >= map.GetLength(1))
                    continue;
                if(map[vx,vy] != 1 && !book[vx,vy])
                {
                    textBox2.Text += $"({vy},{vx})";
                    book[vx, vy] = true;
                    dfs(vx, vy);
                }
            }
        }
    }
}
