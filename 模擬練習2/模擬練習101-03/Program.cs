using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模擬練習101_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入徑向距離(r) = ");
            double r = double.Parse(Console.ReadLine());
            Console.Write("請輸入逕向多項式的次數(n) = ");
            int n = int.Parse(Console.ReadLine());
            for(int m =-n;m<= n;m++)
            {
                if ((n - Math.Abs(m)) % 2 != 0)
                    continue;
                double ans = 0;
                for(int s= 0;s<= (n-Math.Abs(m))/2;s++)
                {
                    if (s % 2 == 0)
                        ans += stair(n - s) /( stair(s) * stair((n + Math.Abs(m)) / 2 - s) * stair((n - Math.Abs(m)) / 2 - s)) * Math.Pow(r, n - 2 * s);
                    else
                        ans += -(stair(n - s) /( stair(s) * stair((n + Math.Abs(m)) / 2 - s) * stair((n - Math.Abs(m)) / 2 - s) )* Math.Pow(r, n - 2 * s));                    
                }
                Console.WriteLine($"\n計算徑向多項式(radial polynomials) ... , r = {r}, n = {n} , m = {m}");
                Console.WriteLine($"所求之徑向多項式 = {ans}");
            }
            Console.WriteLine("\n計算完畢...");
            Console.Read();
        }
       static  double stair(int num)
        {
            double val = 1;
            for (int i = 1; i <= num; i++)
                val *= i;
            return val;
        }
    }
}
