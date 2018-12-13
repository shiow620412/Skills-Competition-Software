using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionCup107_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            for(int i =1; i<= Math.Max(input[0],input[1]);i++)
            {
                if(input[0] >i && input[0] % i ==0)
                {
                    a.Add(i);
                }
                if(input[1]>i && input[1]%i==0)
                {
                    b.Add(i);
                }
            }
            if (a.Sum() ==input[1] && b.Sum()==input[0])
                Console.Write("true");
            else
                Console.Write("false");
            Console.Read();
        }
    }
}
