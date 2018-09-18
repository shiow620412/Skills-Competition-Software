using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_105_3
{
    class Program
    {
        static int height;
        static Point p1, p2, p3;
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 40);
            height = 40 - 2;
            do
            {
                Console.Clear();
                Console.WriteLine("請選擇操作項目\n" +
                    "\t<1>輸入兩點座標(x1,y1),(x2,y2)繪一線\n" +
                    "\t<2>輸入三個頂點座標(x1,y1),(x2,y2),(x3,y3)繪三角形\n" +
                    "\t<3>上題三角形水平翻轉");
                switch(getInput("請選擇："))
                {                   
                    case "1":
                        Func1();
                        break;
                    case "2":
                        Func2();
                        break;
                    case "3":
                        Func3();
                        break;

                }
                Console.SetCursorPosition(0, 40 - 1);
            } while (getInput("繼續：請按1,結束：請按0：") == "1");
        }
        static void  Func1()
        {
            p1 = new Point(getInput("(x1,y1)："));
            p2 = new Point(getInput("(x2,y2)："));
            Console.Clear();
            drawLine(p1, p2);
        }
        static void Func2()
        {
            p1 = new Point(getInput("(x1,y1)："));
            p2 = new Point(getInput("(x2,y2)："));
            p3 = new Point(getInput("(x3,y3)："));
            Console.Clear();
            drawLine(p1, p2);
            drawLine(p2, p3);
            drawLine(p3, p1);
            
        }
        static void Func3()
        {
            Point[] pts = new Point[] { p1, p2, p3 };
            Array.Sort(pts, (a, b) => a.x.CompareTo(b.x));
            int min = pts[0].x;
            int max = pts[2].x;
            int mid = min+(max - min) / 2;
            for(int i =0;i<pts.Length;i++)
            {
                pts[i].x = mid - pts[i].x+mid;
            }
            Console.Clear();
            drawLine(p1, p2);
            drawLine(p2, p3);
            drawLine(p3, p1);
        }
        static void drawLine(Point p1,Point p2)
        {
            int mx = p2.x - p1.x;
            int my = p2.y - p1.y;
            int steps = Math.Abs(mx) > Math.Abs(my) ? Math.Abs(mx) : Math.Abs(my);
            float xa = mx / (float)steps;
            float ya = my / (float)steps;
            float x = p1.x;
            float y = p1.y;
            setPoint(p1.x, p1.y);
            setPoint(p2.x, p2.y);
            for(int i =0;i< steps;i++)
            {
                x += xa;
                y += ya;
                setPoint((int)Math.Round(x), (int)Math.Round(y));
            }
        }
        static void setPoint(int x,int y)
        {
            Console.SetCursorPosition(x, height - y);
            Console.Write("*");
        }
        static string getInput(string str)
        {
            Console.Write(str);
            return Console.ReadLine();
        }
    }
    class Point
    {
        public int x, y;
        public Point(string str)
        {
            int[] val = Array.ConvertAll(str.Split(','), int.Parse);
            x = val[0];
            y = val[1];
        }
    }
}
