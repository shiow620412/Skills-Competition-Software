using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬練習101_05
{
    public partial class Form1 : Form
    {
        TextBox[] txt = new TextBox[9];
        TextBox[] ans = new TextBox[9];
        public class Node
        {
            public Node father;
            public byte[] status;
            public Node(byte[] b,Node n)
            {
                status =b;
                father = n;
            }

        }
        public Form1()
        {
            InitializeComponent();
            
            for(int i=0;i<9;i++)
            {
                txt[i] = new TextBox()
                {
                    Size = new Size(30, 30),
                    Location = new Point(30 + i % 3 * 50, 30 + i / 3 * 30)
                };
                ans[i] = new TextBox()
                {
                    Size = new Size(30, 30),
                    Location = new Point(250 +i % 3 * 50, 30 + i / 3 * 30)
                };
            }
            Controls.AddRange(txt);
            Controls.AddRange(ans);
        }
        public byte[] textTobyte(TextBox[] t)
        {

            TextBox[] arr = new TextBox[t.Length];
            

            for (int i = 0; i < t.Length; i++)
            {
                arr[i] = new TextBox() { Text = t[i].Text };
                if (arr[i].Text == "")
                    arr[i].Text = "0";
            }
            return  Array.ConvertAll(arr, x => byte.Parse(x.Text));
           
        }
        string getString(byte[] b)
        {
            string s = "";
            for (int i = 0; i < b.Length; i++)
                s += b[i].ToString();
                   
            return s;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
        public void Swap<T> (ref T a ,ref T b)
        {
            T temp = b;
            b = a;
            a = temp;
        }
        Hashtable ht = new Hashtable();
        Queue<Node> queue = new Queue<Node>();
        public void getNext(Node n)
        {
            int scan = 0;
            for (int i = 0; i < n.status.Length; i++)
                if (n.status[i] == 0)
                {
                    scan = i;
                    break;
                }
            byte[] temp;
            if (scan % 3 != 0)
            {
                temp = (byte[])n.status.Clone();
                Swap(ref temp[scan ], ref temp[scan  - 1]);
                if(!ht.ContainsKey(getString(temp)))
                {
                    ht.Add(getString(temp),true);
                    queue.Enqueue(new Node(temp, n));
                }
            }
            if (scan % 3 != 2)
            {
                temp = (byte[])n.status.Clone();
                Swap(ref temp[scan ], ref temp[scan + 1]);
                if (!ht.ContainsKey(getString(temp)))
                {
                    ht.Add(getString(temp), true);
                    queue.Enqueue(new Node(temp, n));
                }
            }
            if (scan / 3 != 2)
            {
                temp = (byte[])n.status.Clone();
                Swap(ref temp[scan], ref temp[scan  + 3]);
                if (!ht.ContainsKey(getString(temp)))
                {
                    ht.Add(getString(temp), true);
                    queue.Enqueue(new Node(temp, n));
                }
            }
            if (scan / 3 != 0)
            {
                temp = (byte[])n.status.Clone();
                Swap(ref temp[scan ], ref temp[scan  - 3]);
                if (!ht.ContainsKey(getString(temp)))
                {
                    ht.Add(getString(temp), true);
                    queue.Enqueue(new Node(temp, n));
                }
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bool[] book = new bool[8];
            for(int i =0;i<txt.Length;i++)
            {
                if (i == 4)
                    continue;
                int val = rnd.Next(1, 9);
                while (book[val - 1])
                    val = rnd.Next(1, 9);
                book[val - 1] = true;
                txt[i].Text = val.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
   
            Node start = new Node(textTobyte(txt), null);
            string ans_str = getString(textTobyte(ans));
            ht.Clear();
            queue.Clear();
            ht.Add(getString(start.status), true);
            bool goal = false;
            queue.Enqueue(start);
            Node temp=null;
            while(queue.Count>0 )
            {
                temp = queue.Dequeue();
                if (getString(temp.status) == ans_str)
                {
                    goal = true;
                    break;
                }
                else
                    getNext(temp);
            }
            if (goal)
            {
                Stack<Node> output = new Stack<Node>();
                while (temp.father != null)
                {
                    output.Push(temp);
                    temp = temp.father;
                }
                output.Push(start);
                int total = output.Count;
                int count = 1;
                Timer t = new Timer() { Interval = ((Button)sender).Equals(button2) ? 500 : 1000 };
                t.Tick += (s, evt) =>
                {

                    byte[] bytes = output.Pop().status;

                    for (int i = 0; i < txt.Length; i++)
                    {
                        txt[i].Text = bytes[i] == 0 ? "" : bytes[i].ToString();
                    }
                    label2.Text = $"{count++}/{total}";
                    if (output.Count == 0)
                    {
                        t.Stop();
                    }
                };
                t.Start();
            }
            else
                label2.Text = "無解";

        }
    }
}
