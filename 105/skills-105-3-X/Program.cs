using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace skills_105_3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("請選擇操作項目：");
                Console.WriteLine("\t<1>輸入二點座標(x1,y1),(x2,y2)繪一線：");
                Console.WriteLine("\t<2>輸入三個頂點座標(x1,y1),(x2,y2),(x3,y3)繪三角形：");
                Console.WriteLine("\t<3>上題三角形水平翻轉：");
                Console.Write("請選擇：");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        func1();
                        break;
                    case 2:
                        func2();
                        break;
                    case 3:
                        func3();
                        break;
                }
                Console.Write("繼續：請按1，結束：請按0：");
            } while (Console.ReadLine() == "1");            
        }
        static public void func1()
        {
            int[] temp = new int[2];
            Point[] p = new Point[2];
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write($"(x{i + 1},y{i + 1}) ：");
                temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                p[i] = new Point(temp[0], temp[1]);
            }
            int minX = p.ToList().Min(x => x.x);
            int maxX = p.ToList().Max(x => x.x);
            double a = (p[1].y - p[0].y);
            double b = (p[1].x - p[0].x);

            double c = p[0].x * a - p[0].y * b;
            List<Point> lst = new List<Point>();
            for (double i = minX; i <= maxX; i++)
            {
                lst.Add(new Point(i, (i * a - c) / b));
            }
            lst = lst.OrderBy(x => x.y).ToList();
            for (int i = lst.Last().y; i >= lst.First().y; i--)
            {
                bool output = false;
                lst.ForEach(x =>
                {
                    if (x.y == i)
                    {
                        Console.WriteLine("*".PadLeft(x.x));
                        output = true;
                    }
                });
                if (!output)
                    Console.WriteLine();
            }
        }
        static public void func2()
        {
            int[] temp = new int[2];
            Point[] p = new Point[3];
            for (int i = 0; i < p.Length; i++)
            {
                Console.Write($"(x{i + 1},y{i + 1}) ：");
                temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                p[i] = new Point(temp[0], temp[1]);
            }
            List<Point> lst = new List<Point>();
            int index = 0;
            for (int i = 0;i<3; i++)
            {                
                if (i + 1 == 3)
                    index = 0;
                else
                    index = i + 1;
                int minX = Math.Min(p[i].x, p[index].x);
                int maxX = Math.Max(p[i].x, p[index].x);
                double a = (p[index].y - p[i].y);
                double b = (p[index].x - p[i].x);

                double c = p[i].x * a - p[i].y * b;
               
                for (double j = minX; j <= maxX; j++)
                {
                    lst.Add(new Point(j, Math.Round(j * a - c / b) ));
                }
            }
            lst = lst.OrderBy(x => x.y).ToList();
            Console.Clear();
            
            
           
           foreach(var item in lst)
            {
                Console.SetCursorPosition(item.x, item.y);
                Console.Write("*");
            }
            
        }
        static public void func3()
        {

        }
    }
    class Point
    {
        public int x, y;
        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point(double x , double y)
        {
            this.x = (int)x;
            this.y = (int)y;
        }
    }
}
