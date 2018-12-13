using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace 模擬練習1_03
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("請選擇操作項目：\r\n\t(1)輸入模型資料:\r\n\t(2)計算平均相似度:\r\n\t(3)顯示個資料相似度:\r\n");
                switch(read("請選擇："))
                {
                    case "1":
                        function1();
                        break;
                    case "2":
                        function2();
                        break;
                    case "3":
                        function3();
                        break;
                }
            } while (read("繼續:請按1，結束:請按0:") == "1");
            
            
        }        
        class model
        {
            public int[] up;
            public int[] mid;
            public int[] down;
            public float[] diff;
            public int[] data;
            public model(int[] up ,int[] mid,int[] down)
            {
                this.up = up;
                this.mid = mid;
                this.down = down;
            }
            public void calcDiff(int [] temp)
            {
                data = temp;
                diff = new float[temp.Length];
                for (int i = 0; i < diff.Length; i++)
                {
                    if (temp[i] >= up[i] | temp[i] <= down[i])
                        diff[i] = 0;
                    else if (temp[i] == mid[i])
                        diff[i] = 1;
                    else
                    {
                        if(temp[i] > mid[i] && temp[i] < up[i])
                        {
                            float avg = 1f / (up[i] - mid[i]);
                            int val = mid[i];
                            diff[i] = 1;
                            while (val != temp[i])
                            {
                                diff[i] -= avg;
                                val++;
                            }
                        }
                        else if (temp[i] < mid[i] && temp[i] > down[i])
                        {
                            float avg = 1f / (mid[i] - down[i]);
                            int val = down[i];
                            while(val != temp[i])
                            {
                                diff[i] += avg;
                                val++;
                            }
                        }
                    }
                }
                Console.WriteLine("\r\n平均相似度為 " + diff.Average());                
            }
            public void printModel()
            {
                Console.Write("數值串列(上限):");
                for (int i = 0; i < up.Length; i++)
                    Console.Write(up[i].ToString().PadLeft(4) + " ");
                Console.Write("\r\n數值串列(中心):");
                for (int i = 0; i < mid.Length; i++)
                    Console.Write(mid[i].ToString().PadLeft(4) + " ");
                Console.Write("\r\n數值串列(下限):");
                for (int i = 0; i < down.Length; i++)
                    Console.Write(down[i].ToString().PadLeft(4) + " ");
            }
            public void printDiff()
            {
                printModel();
                Console.Write("\r\n      資料串列:");
                for (int i = 0; i < data.Length; i++)
                {
                    Console.Write(data[i].ToString().PadLeft(4) + " ");
                }
                Console.Write("\r\n  各資料相似度:".PadLeft(15));
                for (int i = 0; i < diff.Length; i++)
                {
                    Console.Write(diff[i].ToString("0.00") +" ");
                }
                Console.Write("\r\n");
            }
         
        }
       static model m;
        static void function1()
        {
            int[] up, mid, down;
            string[] input = File.ReadAllLines(read("請輸入【模型資料】檔名："));            
            up = Array.ConvertAll(input[0].Split(' '), int.Parse);
            mid = Array.ConvertAll(input[1].Split(' '), int.Parse);
            down = Array.ConvertAll(input[2].Split(' '), int.Parse);
            Console.Write("\r\n");
            m = new model(up, mid, down);
            m.printModel();
            Console.Write("\r\n\r\n");
    }
        static void function2()
        {
            string file = read("請輸入【資料串列】檔名：");
            Console.WriteLine("已開啟【資料串列】檔名：" + file);
            m.calcDiff(Array.ConvertAll(File.ReadAllText(file).Split(' '),int.Parse) );
        }
        static void function3()
        {
            m.printDiff();
        }
        static string read(string s)
        {
            Console.Write(s);
            return Console.ReadLine();
        }
    }
}
