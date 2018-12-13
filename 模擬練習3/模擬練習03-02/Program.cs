using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模擬練習03_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入N人數:");
            int n = int.Parse(Console.ReadLine());
            Console.Write("請輸入M人數:");
            int m = int.Parse(Console.ReadLine());
            int[] book = new int[n + 1];
            for (int i = 1; i <= n; i++)
                book[i] = 1;            
            int count = 0;
            int index = 0;
            Console.Write("淘汰順序:");
            while(book.Count(x=>x==0) != book.Length-1)
            {
                while(count < m )
                {
                    index++;
                    if (index == book.Length)
                        index = 1;
                    while (book[index] == 0) 
                    {
                        index++;
                        if (index == book.Length)
                            index = 1;
                    }
                    count++;                    
                }
                book[index] = 0;
                count = 0;
                Console.Write($"{index} ");
            }
            Console.Write("\n最後贏家:");
            for (int i = 0; i < book.Length; i++)
                if (book[i] == 1)
                {
                    Console.Write(i);
                    break;
                }
            Console.Read();
        }
    }
}
