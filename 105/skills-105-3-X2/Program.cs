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
                Console.Write("請選擇操作項目：" +
                "\n\t<1>輸入二點座標(x1,y1),(x2,y2)繪一線：" +
                "\n\t<2>輸入三點頂點座標(x1, y1),(x2, y2),(x3, y3)繪三角形：" +
                "\n\t<3>上題三角形水平翻轉\n");
                switch (getInput("請選擇："))
                {
                    case "1":
                        func1();
                        break;
                    case "2":
                        func2();
                        break;
                    case "3":
                        func3();
                        break;
                }
                Console.SetCursorPosition(0, height + 1);
            }
            while (getInput("繼續：請按1，結束：請按0：") == "1");
            

        }
        static void func1 ()
        {
            
            p1 = new Point(getInput("(x1,y1)："));
            p2 = new Point(getInput("(x2,y2)："));
            Console.Clear();
            drawLine(p1, p2);            
        }
        static void func2()
        {
            
            p1 = new Point(getInput("(x1,y1)："));
            p2 = new Point(getInput("(x2,y2)："));
            p3 = new Point(getInput("(x3,y3)："));
            Console.Clear();
            drawLine(p1, p2);
            drawLine(p2, p3);
            drawLine(p3, p1);
        }
        static void func3()
        {
            Console.Clear();
            p1 = new Point(getInput("(x1,y1)："));
            p2 = new Point(getInput("(x2,y2)："));
            p3 = new Point(getInput("(x3,y3)："));
            Point[] pts = new Point[] { p1, p2, p3 };
            Array.Sort(pts, (a, b) => a.y.CompareTo(b.y));
            int mid = (pts[0].x + pts[1].x) / 2;
            for (int i =0;i<3;i++)
            {
                Point dp1 = new Point();
                Point dp2 = new Point();
                int val = (i + 1 == 3) ? 0 : i + 1;              
                if(pts[i].x==pts[val].x)
                {
                    dp1.x = pts[i].x - mid;
                    dp2.x = pts[val].x - mid;
                    dp1.y = pts[i].y;
                    dp2.y = pts[val].y;
                    drawLine(dp1, dp2);
                    continue;
                }
                
                dp1.x = (pts[val].x > pts[i].x) ? pts[val].x -  mid : pts[val].x +  mid;
                dp2.x = (pts[val].x > pts[i].x) ? pts[i].x +  mid : pts[i].x -  mid;
                dp1.y = pts[val].y;
                dp2.y = pts[i].y;
                drawLine(dp1,dp2);
            }
            
         
        }
        static void drawLine(Point pt1,Point pt2)
        {
            float a = pt1.x - pt2.x;
            float b = pt1.y - pt2.y;
            float c = a * pt1.x - b * pt1.y;
            int min = 0, max = 0;
            if (pt1.x != pt2.x && pt1.y != pt2.y)
            {
                min = Math.Min(pt1.x, pt2.x);
                max = Math.Max(pt1.x, pt2.x);
                for (int i = min; i <= max; i++)
                {
                    int dy = (int)((a * i - c) / b);
                    setPoint(i, dy);
                }
            }
            else if(pt1.x == pt2.x)
            {
                min = Math.Min(pt1.y, pt2.y);
                max = Math.Max(pt1.y, pt2.y);
                for (int i = min; i <= max; i++)
                {
                    setPoint(pt1.x, i);
                }                
            }
            else
            {
                min = Math.Min(pt1.x, pt2.x);
                max = Math.Max(pt1.x, pt2.x);
                for (int i = min; i <= max; i++)
                {
                    setPoint(i, pt1.y);
                }
            }

        }
        static void setPoint(int x ,int y)
        { 

            Console.SetCursorPosition(x, height - y);
            Console.Write("*");
        }
            
        static string getInput(string str)
        {
            Console.Write(str);
            return Console.ReadLine();
        }
        class Point
        {
            public int x;
            public int y;
            public Point(string str)
            {
                int[] val = Array.ConvertAll(str.Split(','), int.Parse);
                this.x = val[0];
                this.y = val[1];
            }
            public Point()
            {

            }
        }

    }
}

