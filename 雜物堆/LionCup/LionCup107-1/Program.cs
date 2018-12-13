using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionCup107_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int row = int.Parse(input[0]);
            int height = 0;
            bool reverse = false;
            for(int i =0;i < input[1].Length;i++)
            {
                if (!reverse)
                    height++;
                else
                    height--;
                Console.SetCursorPosition(i, height);
                Console.Write(input[1][i].ToString());
                if (height == row | (height==1&& i !=0))
                    reverse = !reverse;
            }
            Console.Read();
        }
    }
}
