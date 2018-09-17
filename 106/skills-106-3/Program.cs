using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_106_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入行程Process數量(MAX 5)：");
            int pCount = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸入每個行程的執行時間burst_time...");
            List<process> list = new List<process>();
            for (int i = 0; i < pCount; i++)
            {
                Console.Write($"P{i + 1}：");
                list.Add(new process(int.Parse(Console.ReadLine()),i+1));
            }
            Console.Write("請輸入時間配額time_quantum：");
            int quantum = int.Parse(Console.ReadLine());
            Console.WriteLine("各行程Process執行順序為...");
            int num = 0;
            int total = 0;
            while(list.Count(x=>x.isFinish)!= pCount)
            {
                process p = list[num];
                int run = 0;
                Console.WriteLine($"{total.ToString().PadLeft(2,'0')}:P{list[num].CurrentIndex}");
                if (p.RunTime > quantum)
                {
                    run =  quantum;
                    p.RunTime -= quantum;
                }
                else
                {
                    run = p.RunTime;
                    p.RunTime = 0;
                    list[num].isFinish = true;
                }
                total += run;
                for(int i = 0; i< list.Count ;i ++)
                {
                    if(!list[i].isFinish && i!=num)
                    {
                        list[i].WaitTime += run;
                    }
                }
                while(list.Count(x=>x.isFinish)!=list.Count)
                {
                    if (num + 1 == pCount)
                        num = 0;
                    else
                        num++;
                    if (!list[num].isFinish)
                        break;
                }
            }
            Console.WriteLine($"{total.ToString().PadLeft(2, '0')}:P{list[num].CurrentIndex}");
            foreach (var item in list)
                Console.WriteLine($"P{item.CurrentIndex}等待時間：{item.WaitTime}");
            Console.Read();
        }
        class process
        {
            public int CurrentIndex;
            public int RunTime;
            public int WaitTime;
            public bool isFinish;
            public process(int RunTime ,int CurrentIndex)
            {
                this.RunTime = RunTime;
                this.CurrentIndex = CurrentIndex;
            }
        }
    }
}
