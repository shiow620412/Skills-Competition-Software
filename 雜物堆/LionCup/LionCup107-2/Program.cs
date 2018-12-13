using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionCup107_2
{
    class Program
    {
        static int carry = 0;
        static void Main(string[] args)
        {
           string[] input = Console.ReadLine().Split(' ');
           //string[] input = new string[] { "15", "FA", "1F" };
            carry = int.Parse(input[0]);
            int a = getNum(input[1][0].ToString()) *carry+ getNum(input[1][1].ToString());
            int[] b = new int[] { getNum(input[2][0].ToString()) ,getNum(input[2][1].ToString() )};
            if( (a|b[0]|b[1]) > 2000000000  )
            {
                Console.Write("Error");
                Console.Read();
                return;
            }
            int[] c = new int[] { b[0] * a * carry, b[1] * a };
            string[] output = new string[5];
            output[0] = input[1];
            output[1] = input[2];
            output[2] = getStr(c[1]);
            output[3] = getStr(c[0]);
            output[4] = getStr(c[0] + c[1]);
            Console.Write(string.Join(" ", output));
            Console.ReadLine();
        }
       static string getStr(int val)
        {
            Stack<string> str = new Stack<string>();
            while(val / carry !=0)
            {
                if (val % carry >= 10)
                    str.Push(Convert.ToChar(val % carry +55).ToString());
                else
                    str.Push( (val % carry).ToString());
                val /= carry;
            }
            if (val % carry >= 10)
                str.Push(Convert.ToChar(val+55).ToString());
            else
                str.Push((val).ToString());
            return string.Join("", str.ToArray());
        }
        static int getNum(string s)
        {
            int val = 0;
            if (!int.TryParse(s, out val))
                return (Convert.ToInt16(Convert.ToChar(s)) - 55) >= carry ? 2147483647: Convert.ToInt16(Convert.ToChar(s)) - 55;
            else
                return val >= carry ? 2147483647 : val;
        }
    }
}
