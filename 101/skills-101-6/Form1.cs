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
namespace skills_101_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                string[] input = File.ReadAllLines(ofd.FileName);
                string[] temp = input[0].Split(' ');
                 map = new string[input.Length, temp.Length];
                for(int i =0;i < input.Length;i++)
                {
                    temp = input[i].Split(' ');
                    for(int j =0;j<temp.Length;j++)
                    {
                        map[i,j] = temp[j];
                    }
                }
               
                book = new bool[map.GetLength(0), map.GetLength(1)];
                book[0, 0] = true;
                record.Add(new Point(0, 0));
                dfs(0, 0);
                
            }
        }
        List<Point> record = new List<Point>();
        string[,] map;
        bool[,] book;
        int[,] road = new int[,] {
                    { 0, -1 }, //北
                    { 1, -1 }, //東北
                    { 1, 0 }, //東
                    { 1, 1 }, //東南
                    { 0, 1 },//南
                    { -1 ,1 },//西南
                    { -1, 0},//西
                    {-1,-1 }//西北
                };
        bool goal = false;
        void dfs (int x, int y)
        {
            if( x == map.GetUpperBound(0) && y== map.GetUpperBound(1))
            {
                goal = true;
                textBox2.Clear();
                record.ForEach( i =>
                {
                    textBox2.Text += $"({i.X},{i.Y})";
                });
            }
            for(int i =0; i<road.GetLength(0);i++)
            {
                int vx = x + road[i, 0];
                int vy = y + road[i, 1];
                if (goal)
                    break;
                if (vx < 0 | vy < 0 | vx > map.GetUpperBound(0) | vy > map.GetUpperBound(1)  )
                    continue;
                if (map[vy, vx] == "1" | book[vy, vx])
                    continue;
                book[vy, vx] = true;
                record.Add(new Point(vy, vx));
                dfs(vx, vy);
                
               // book[vy, vx] = false;                
            }
        }
    }
}
