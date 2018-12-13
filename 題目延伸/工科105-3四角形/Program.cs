using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工科105_3四角形
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.SetBufferSize(120, 30);
                Console.Clear();
                Console.Write("請選擇操作項目:\r\n\t(1)輸入二點座標 座標1,座標2 繪一線\r\n\t(2)輸入四個頂點座標 座標1,座標2,座標3,座標4繪製四角形\r\n\t(3)上題四角形水平翻轉\r\n");
                switch(getString("請選擇:"))
                {
                    case "1":
                        Fun1();
                        break;
                    case "2":
                        Fun2();
                        break;
                    case "3":
                        Fun3();
                        break;
                }
                Console.SetCursorPosition(0, 29);
            } while (getString("是否繼續(Y/N):").ToUpper() == "Y");
        }
        class Point
        {
            public int x;
            public int y;
            public Point(string[] s) {
                int[] temp = Array.ConvertAll(s, int.Parse);
                x = temp[0];
                y = temp[1];
            }
        }
        static void drawLine(Point p1,Point p2)
        {
            int dx = p1.x - p2.x;
            int dy = p1.y - p2.y;
            int steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) :Math.Abs( dy);
            float offsetX = dx / (float)steps;
            float offsetY = dy / (float)steps;
            int x = p2.x;
            int y = p2.y;
            Console.SetCursorPosition(x, 28 - y);
            Console.Write("*");
            for (int i = 0; i < steps; i++)
            {
                x += (int)Math.Round(offsetX);
                y += (int)Math.Round(offsetY);
                Console.SetCursorPosition(x, 28 - y);
                Console.Write("*");
            }

        }
        static Point[] p;
        static void Fun1()
        {
            p=new Point[2];
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new Point(getString($"座標{i + 1}:").Split(','));
            }

            Console.Clear();
            drawLine(p[0], p[1]);
                     
        }
        static void Fun2()
        {
            p = new Point[4];
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new Point(getString($"座標{i + 1}:").Split(','));
            }

            Console.Clear();
            Array.Sort(p, (a,b) => a.x.CompareTo(b.x));
            drawLine(p[0], p[1]);
            drawLine(p[0], p[2]);
            drawLine(p[3], p[1]);
            drawLine(p[3], p[2]);

         
        }
        static void Fun3()
        {
            int mid = Math.Abs(p.Max(item=>item.x) - p.Min(item=>item.x))/2;
            for(int i =0;i<p.Length;i++)
            {
                p[i].x = p[i].x > mid ? mid - Math.Abs(mid - p[i].x) : mid +Math.Abs(mid - p[i].x);
            }
            Console.Clear();
            drawLine(p[0], p[1]);
            drawLine(p[0], p[2]);
            drawLine(p[3], p[1]);
            drawLine(p[3], p[2]);
        }
        static string getString(string s)
        {
            Console.Write(s);
            return Console.ReadLine();
        }
    }
}
