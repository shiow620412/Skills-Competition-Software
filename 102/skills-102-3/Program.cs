using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skills_102_3
{
    class Program
    {
        class point
        {
            public int road;
            public int length;
            public point(int a,int b)
            {
                road = a;
                length = b;
            }
        }
        static int Min = 99999;
        static List<point> p = new List<point>();
        static string print = "";
        static void dfs (int step,int count)
        {
            if( step == 7)
            {
                if (Min > count)
                {
                    Min = count;
                    print = "路徑次序:";
                    p.ForEach(x =>
                    {
                        print += x.road.ToString().PadLeft(3);
                    });
                    print += "\r\n連線數值:";
                    p.ForEach(x =>
                    {
                        print += x.length.ToString().PadLeft(3);
                    });
                }
                return;
            }
            for(int i =1;i<8;i++)
            {
                if (i == step)
                    continue;
                if(line[step,i] != 0)
                {
                    p.Add(new point(i, line[step, i]));
                    dfs(i,count+line[step,i]);
                    p.RemoveAt(p.Count - 1);
                }
            }
        }
        static int[,] line;
        static void Main(string[] args)
        {
            Console.Write("輸入要開啟的檔名(*.txt):");
            line = new int[8, 8];
           // int dot = int.Parse(Console.ReadLine());
            string[] input = File.ReadAllLines(Console.ReadLine());
            for(int i =0;i< input.Length;i++)
            {
                int[] input2 = Array.ConvertAll(input[i].Split(' '), int.Parse);
                //int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                line[input2[0], input2[1]] = input2[2];
            }
            p.Add(new point(1, 0));
            dfs(1,0);
            Console.WriteLine($"最低成本總和:{Min}");
            Console.Write(print);
            Console.Read();

        }
    }
}
