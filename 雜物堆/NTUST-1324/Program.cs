using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTUST_1324
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
                int[,] d = new int[str1.Length + 1, str2.Length + 1];
                int cost = 0;
                for (int i = 0; i <= str1.Length; i++)
                    d[i, 0] = i;
                for (int j = 0; j <= str2.Length; j++)
                    d[0, j] = j;
                for (int i = 1; i <= str1.Length; i++)
                    for (int j = 1; j <= str2.Length; j++)
                    {
                        if (str1[i - 1] == str2[j - 1])
                            cost = 0;
                        else
                            cost = 1;
                        d[i, j] = getMin(d[i - 1, j] + 1, d[i, j - 1] + 1, d[i - 1, j - 1] + cost);
                    }
                Console.WriteLine($"distance = {d[str1.Length, str2.Length]}");
            }
            while (Console.ReadLine() == "Y");
            

            Console.Read();
        }
        static int getMin(int a, int b,int c)
        {
            int min = int.MaxValue;
            if (min > a) min = a;
            if (min > b) min = b;
            if (min > c) min = c;
            return min;
        }
    }
}
