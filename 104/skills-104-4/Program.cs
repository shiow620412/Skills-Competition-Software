using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skills_104_4
{
 
    class Program
    {

        static model[] m;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("請選擇操作項目:\n\t(1)輸入模型資料:\n\t(2)計算平均相似度:\n\t(3)顯示各資料相似度:\n");
                switch (input("請選擇："))
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
            } while (input("繼續:請按1，結束:請按0:") == "1");
        }
        static void Func1()
        {
            m = new model[int.Parse(input("輸入模型資料，總筆數為："))];
            Console.Write("    序列( x軸)：");
            for (int i = 0; i < m.Length; i++) Console.Write( i.ToString().PadLeft(2));
            Console.Write("\n");
            int[] up, mid, down;
            up = Array.ConvertAll(input("數值串列(上限)：").Split(' '), int.Parse);
            mid = Array.ConvertAll(input("數值串列(中心)：").Split(' '), int.Parse);
            down = Array.ConvertAll(input("數值串列(下限)：").Split(' '), int.Parse);
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new model();
                m[i].up = up[i];
                m[i].mid = mid[i];
                m[i].down = down[i];
            }
        }
        static void Func2()
        {
            if( m == null)
            {
                int[] up, mid, down;
                string[] temp = File.ReadAllLines("Q4_InputModel.txt");
                up = Array.ConvertAll(temp[0].Split(' '), int.Parse);
                mid = Array.ConvertAll(temp[1].Split(' '), int.Parse);
                down = Array.ConvertAll(temp[2].Split(' '), int.Parse);
                m = new model[up.Length];
                for (int i = 0; i < m.Length; i++)
                {
                    m[i] = new model();
                    m[i].up = up[i];
                    m[i].mid = mid[i];
                    m[i].down = down[i];
                }
            }
            string file = input("請輸入「資料串列」檔名：");
            int[] data = Array.ConvertAll(File.ReadAllText(file).Split(' '),int.Parse);
            Console.WriteLine($"已開啟「資料串列」檔名：{file}");
            float output = 0;
            for(int i =0;i<m.Length;i++)
            {
                output += m[i].getSimilar(data[i]);
            }
            output /= m.Length;
            Console.WriteLine($"平均相似度為{output}");


        }
        static void Func3()
        {

        }
        static string input(string str)
        {
            Console.Write(str);
            return Console.ReadLine();
        }
        public  class model
        {
            public int up;
            public int mid;
            public int down;
            public float getSimilar(int val)
            {
                if (val == mid)
                {
                    return 1;
                }
                else if (val >= up | val <= down)
                    return 0;
                else if(val > mid)
                {
                    float add = 1f / (mid -up);
                    float output = 1;
                 
                   for(int i = mid+1; i <= val;i++)
                    {
                        output += add;
                    }
                    return output;
                }
                else
                {
                    float add = 1f / (down - mid);
                    float output = 1;
                    for (int i = mid-1; i >= val; i--)
                    {
                        output += add;
                    }
                    return output;
                }
            }
        }
    }
    
}
