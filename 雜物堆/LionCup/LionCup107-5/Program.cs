using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace LionCup107_5
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] input = Array.ConvertAll(Console.ReadLine().Split(' '), float.Parse);
            calc(input[0], input[1]);
          //  BigInteger num1 = BigInteger.Parse(input[0].ToString());
           // BigInteger num2 = BigInteger.Parse(input[1].ToString());
            //BigInteger ans = num1 * num2;
            //Console.Write(ans.ToString());
            Console.Write( input[0] * input[1]);
            Console.Read();
        }
        static void calc(float v1 , float v2)
        {
            string s1 = v1.ToString();            
            string s2 = v2.ToString();
            Console.WriteLine($"x={v1} , y={v2}");
            if ( v2 < 10 | v1 < 10)
                return;
            int lenS1 = s1.Length % 2 == 0? s1.Length / 2 : s1.Length / 2 + 1;
            int lenS2 = s2.Length % 2 == 0 ? s2.Length / 2 : s2.Length / 2 + 1;
            float a = float.Parse(s1.Substring(0, lenS1));
            float b = float.Parse(s1.Substring(lenS1));
            float c = float.Parse(s2.Substring(0, lenS2));
            float d = float.Parse(s2.Substring(lenS2));
            calc(a,c);
            calc(b, d);
            calc((a + b), (c + d));

        }
    }
}
