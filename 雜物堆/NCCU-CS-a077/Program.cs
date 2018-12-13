using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCCU_CS_a077
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            { 
                int N1 = Convert.ToInt32(Console.ReadLine(), 2);
                int N2 = Convert.ToInt32(Console.ReadLine(), 2);
                bool pair = false;

                for (int i = 2; i <= Math.Max(N1, N2); i++)
                {
                    if (N1 % i == 0 && N2 % i == 0)
                    {
                        pair = true;
                        break;
                    }
                }
                if(!pair)
                    Console.WriteLine($"Pair #1: Love is not all you need !\r\nN1 = {N1} , N2 = {N2}");
                else
                    Console.WriteLine($"Pair #1: All you need is love!\r\nN1 = {N1} , N2 = {N2}");
                Console.WriteLine("是否繼續配對(Y/N)");
            }
            while (Console.ReadLine() == "Y") ;
        }
    }
}
