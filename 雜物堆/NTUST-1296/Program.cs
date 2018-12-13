using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTUST_1296
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int i = 0; i < arr.Length; i++)
            {
                int min = int.MaxValue;
                int index = 0;
                for (int j = i; j < arr.Length; j++)
                    if (min > arr[j]) {
                        min = arr[j];
                        index = j;
                    }
                int temp = 0;
                temp = arr[i];
                arr[i] = min;
                arr[index] = temp;
            }
            
            Console.WriteLine(string.Join(" ", Array.ConvertAll(arr.Reverse().ToArray(), new Converter<int, string>(x => x.ToString()))) );
            Console.Read();
        }
    }
}
