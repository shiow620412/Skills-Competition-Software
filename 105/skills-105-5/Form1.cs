using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_105_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int tradition;
        int[] data = new int[4];
        private void button2_Click(object sender, EventArgs e)
        {
            List<Node> n = new List<Node>();
            Stack<Node> s = new Stack<Node>();
            for (int i =0;i< 4;i++)
            {
                Node node = new Node();
                node.Index = i;
                node.Num = data[i];
                n.Add(node);
            }
            n = n.OrderBy(x => x.Num).ToList();
            for(int i = n.Count-1;i>-1;i--)
            {
                s.Push(n[i]);
            }
            while (s.Count>0)
            {
                Node node = new Node();
                node.Index = n.Count ;
                if (s.Count < 2)
                    break;
                Node tempN1 = s.Pop();
                Node tempN2 = s.Pop();
                node.Num = tempN1.Num + tempN2.Num;
                tempN1.Father = node.Index;
                tempN2.Father = node.Index;
                n.Add(node);
                s.Push(node);
            }
            int Huffman = 0;
            for(int i =0;i<4;i++)
            {
                Node node = n[i];
                int count = 0;
                while(node.Father != 0)
                {
                    node = n[node.Father];
                    count++;
                }
                Huffman += n[i].Num * count;
            }
            label6.Text = Huffman.ToString();
            label8.Text = Math.Round((float)tradition / Huffman,4).ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            data[0] = rnd.Next(1, 1000);
            data[1] = rnd.Next(1, 1000);
            data[2] =  rnd.Next(1, 1000);
            data[3] =  rnd.Next(1, 1000);
            textBox8.Text = data[0].ToString();
            textBox7.Text = data[1].ToString();
            textBox6.Text = data[2].ToString();
            textBox5.Text = data[3].ToString();
            tradition = (data[0]+data[1]+data[2]+data[3]) * 2;
            label5.Text = tradition.ToString();
        }
        class Node
        {
            public int Num;
            public int Index;
            public int Father;
        }
    }
}
