using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_106_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入行程process數量(MAX 5)：");
            int process = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸入每個行程的執行時間");
            List<int> time = new List<int>();
            for(int i =0; i< process;i++)
            {
                Console.Write($"P{i + 1}：");
                time.Add(int.Parse(Console.ReadLine()));
            }
            Console.Write("請輸入時間配額：");
            int quantum = int.Parse(Console.ReadLine());
            
            List<string> output = new List<string>();
            output.Add($"00:P1");
            List<int> wait = new List<int>();
            Queue<int> q = new Queue<int>();
            SortedList<int, bool> order = new SortedList<int, bool>();
            int runorder = 0;
            for (int i = 0; i < time.Count; i++)
            {
                wait.Add(0);
                order.Add(i, false);
                q.Enqueue(time[i]);
           }
            

            int total = 0;
            while(q.Count > 0 )
            {
                int temp = q.Dequeue();
                int run;
                if (temp > quantum)
                {
                    q.Enqueue(temp - quantum);
                    run = quantum;
                }
                else
                {
                    run = temp;
                    order[runorder] = true; 
                }
          
                for(int i = 0; i< time.Count;i++)
                {
                    if (i != runorder && !order[i])
                        wait[i] += run;
                }
                if (runorder + 1 == time.Count)
                    runorder = 0;
                else
                    runorder++;
                while (order[runorder] && order.Count(x=>x.Value)!=time.Count)
                {
                    if (runorder + 1 == time.Count)
                        runorder = 0;
                    else
                        runorder++;
                }
                total += run;
                output.Add($"{total.ToString().PadLeft(2, '0')}:P{runorder + 1}");

            }
            Console.WriteLine("各行程process執行順序為... ");
            foreach (var s in output)
                Console.WriteLine(s);
            for (int i = 0; i < wait.Count; i++)
                Console.WriteLine($"P{i + 1}等待時間：{wait[i]}");
            Console.ReadLine();

        }
    }
}
