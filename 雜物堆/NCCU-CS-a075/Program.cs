using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCCU_CS_a075
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] train = new int[input.Length + 1];
            string ans = "";
            for (int i = 1; i < train.Length; i++)
            {
                train[i] = int.Parse(input[i - 1]);
                ans += i.ToString();
            }
            int index = 1;
            int times = 0;
            for (int j = 1; j < train.Length; j++)
                Console.Write(train[j].ToString().PadRight(3));
            Console.Write("\r\n");
            while (string.Join("", Array.ConvertAll(train, x => x.ToString())).Substring(1) != ans)
            {
                while( train[index] != index)
                {
                    for(int i= index;i<train.Length;i++)
                    {
                        if(train[i] == index)
                        {
                            swap( train[i],  train[i - 1]);
                            for (int j = 1; j < train.Length; j++)
                                Console.Write(train[j].ToString().PadRight(3));
                            Console.Write("\r\n");
                            times++;
                            break;
                        }
                    }
                }
                index++;
            }

            Console.WriteLine($"Optimal train swapping takes {times} swaps.");
            Console.ReadLine();
        }
        static void  swap<T>( T a ,  T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        
    }
}
