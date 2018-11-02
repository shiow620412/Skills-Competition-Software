using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skills_101_5
{
    public partial class Form1 : Form
    {
        TextBox[] txt = new TextBox[9];
        TextBox[] ans = new TextBox[9];
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            bool[] book = new bool[9];
            book[0] = true;
            
            for(int i =0; i<txt.Length;i++)
            {
                int val = 0;
                if (i!=4)
                {
                     val = rnd.Next(0, 9);
                    while (book[val] == true) val = rnd.Next(0, 9);
                    book[val] = true;                   
                }
                txt[i] = new TextBox()
                {
                    Text = val.ToString(),
                    Size = new Size(30, 30),
                    Location = new Point(10 + i % 3 * 50, 10 + i / 3 * 50),
                    TextAlign = HorizontalAlignment.Center
                };
                ans[i] = new TextBox()
                {
                    Text = "",
                    Size = new Size(30, 30),
                    Location = new Point(300 + i % 3 * 50, 10 + i / 3 * 50),
                    TextAlign = HorizontalAlignment.Center                    
                };

            }
            txt[4].Text = "";
            Controls.AddRange(ans);
            Controls.AddRange(txt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bool[] book = new bool[9];
            book[0] = true;
            txt[4].Text = "";
            for(int i=0;i<9;i++)
            {

                if (i == 4)
                    continue;
                int val = rnd.Next(0, 9);
                while (book[val] == true) val = rnd.Next(0, 9);
                book[val] = true;

                txt[i].Text = val.ToString();
            }
            ans.ToList().ForEach(x => x.Clear());
            label2.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Node start = new Node(txtboxToArr(txt), null);
           // Node end = new Node(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 }, null);
            Queue<Node> queue = new Queue<Node>();
            SortedList<int, bool> book = new SortedList<int, bool>();
            queue.Enqueue(start);
            book.Add(start.ToSequence(), true);

            //int endStatus = end.ToSequence();
            bool goal = false;
            List<Node> path = new List<Node>();
            Text = "計算中 . . .";
            while (queue.Count > 0 && !goal)
            {
                Node now = queue.Dequeue();

                //if(now.ToSequence() == endStatus)
                string s = now.ToSequence2();
                if (s.IndexOf("1") != -1)
                    s = s.Substring(s.IndexOf("1")) + s.Remove(s.IndexOf("1"));

                if (s == "12345678")
                {
                    goal = true;
                    path = step(now);
                    continue;
                }

                List<Node> nextPath = getNext(now);
                foreach (var item in nextPath)
                {
                    int sign = item.ToSequence();
                    if (!book.ContainsKey(sign))
                    {
                        book.Add(sign, true);
                        queue.Enqueue(item);
                    }
                }

            }
            int total = path.Count;
            if (goal)
            {
                Timer t = new Timer();
                t.Interval = 1000;
                t.Start();
                t.Tick += (s, evt) =>
                {
                    for (int i = 0; i < 9; i++)
                    {
                        ans[i].Text = path[0].status[i].ToString();
                        if (ans[i].Text == "0")
                            ans[i].Text = "";
                    }
                    path.RemoveAt(0);
                    label2.Text = $"{total - path.Count} / {total}";
                    if (path.Count == 0)
                    {
                        t.Stop();
                    }
                };
            }
            else
                label2.Text = "無解";
            Text = "計算完成";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Node start = new Node(txtboxToArr(txt), null);
         //   Node end = new Node(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 }, null);
            Queue<Node> queue = new Queue<Node>();
            SortedList<int, bool> book = new SortedList<int, bool>();
            queue.Enqueue(start);
            book.Add(start.ToSequence(), true);

           // int endStatus = end.ToSequence();
            bool goal = false;
            List<Node> path = new List<Node>();
            Text = "計算中 . . .";
            while(queue.Count >0 && !goal)
            {
                Node now = queue.Dequeue();

                //if(now.ToSequence() == endStatus)
                string s = now.ToSequence2();
                if(s.IndexOf("1")!=-1)
                s = s.Substring(s.IndexOf("1")) + s.Remove(s.IndexOf("1"));

                if(s == "12345678")
                {
                    goal = true;
                    path = step(now);
                    continue;
                }

                List<Node> nextPath = getNext(now);                   
                foreach(var item in nextPath)
                {
                    int sign = item.ToSequence();
                    if(!book.ContainsKey(sign))
                    {
                        book.Add(sign, true);
                        queue.Enqueue(item);
                    }
                }

            }
            int total = path.Count;
            if (goal)
            {
                Timer t = new Timer();
                t.Interval = 250;
                t.Start();
                t.Tick += (s, evt) =>
                {
                    for(int i =0;i<9;i++)
                    {
                        ans[i].Text = path[0].status[i].ToString();
                        if (ans[i].Text == "0")
                            ans[i].Text = "";
                    }
                    path.RemoveAt(0);
                    label2.Text = $"{total-path.Count} / {total}";
                    if(path.Count ==0)
                    {
                        t.Stop();                        
                    }
                };                                
            }
            else
                label2.Text = "無解";
            Text = "計算完成";
        }
        List<Node> step (Node now)
        {
            List<Node> path = new List<Node>();
            while(now.father != null)
            {
                path.Add(now);
                now = now.father;                
            }
            path.Reverse();
            return path;

        }
        byte[] txtboxToArr(TextBox[] t)
        {
            byte[] arr = new byte[t.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if(txt[i].Text !="")
                arr[i] = byte.Parse(txt[i].Text);
            }
            return arr;
        }
        void swap<T>(ref T a ,ref T b)
        {
            T temp = a;
            a = b;
            b = temp;

        }
        List<Node> getNext(Node now)
        {
            int index = Array.IndexOf<byte>(now.status, 0);
            int col = index % 3;
            int row = index / 3;
            List<Node> next = new List<Node>();
            byte[] nextStatus;            
            if(row !=0)
            {
                nextStatus = (byte[])now.status.Clone();
                swap(ref nextStatus[index], ref nextStatus[index - 3]);
                next.Add(new Node(nextStatus, now));
            }
            if (row != 2)
            {
                nextStatus = (byte[])now.status.Clone();
                swap(ref nextStatus[index], ref nextStatus[index +3]);
                next.Add(new Node(nextStatus, now));
            }
            if (col != 2)
            {
                nextStatus = (byte[])now.status.Clone();
                swap(ref nextStatus[index], ref nextStatus[index +1]);
                next.Add(new Node(nextStatus, now));
            }
            if (col != 0)
            {
                nextStatus = (byte[])now.status.Clone();
                swap(ref nextStatus[index], ref nextStatus[index -1]);
                next.Add(new Node(nextStatus, now));
            }
            return next;
        }
        class Node
        {
            public byte[] status;
            public Node father;
            public Node(byte[] status,Node father)
            {
                this.status = status;
                this.father = father;
            }
            public int ToSequence()
            {
                int result = 0;
                for (int i = 0; i < status.Length; i++)
                    result = result * 10 + status[i];
                return result;
            }
            public string ToSequence2()
            {
                string s = status[0].ToString() + status[1].ToString() + status[2].ToString() +
                    status[5].ToString() + status[8].ToString() + status[7].ToString() +
                    status[6].ToString() + status[3].ToString();
                return s;
            }
        }

        
    }
}
