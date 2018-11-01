using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_101_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入徑向距離(r) = ");
            float r = float.Parse(Console.ReadLine());
            Console.Write("請輸入徑向多項式次數(n) = ");
            float n = float.Parse(Console.ReadLine());
            if (n < 0 | n.ToString().IndexOf('.') != -1)
            {
                Console.WriteLine("n 必須是整數且不可小於0");
                Console.Read();
                return;
            }
            List<float> list = new List<float>();
            for(float i= -n;i<= n;i++)
            {
                if ( (n - Math.Abs(i)) % 2 == 0)
                    list.Add(i);
            }
            //Console.Write(string.Join(" ", Array.ConvertAll(list.ToArray(), x => x.ToString())));
            for(int i =0;i<list.Count();i++)
            {
                double ans = 0;
                float m = Math.Abs(list[i]);
                for(int j =0;j<= (n-m)/2;j++)
                {
                    if (j % 2 == 0)
                        ans += stair(n - j) / (stair(j) * stair((n + m) / 2 - j) * stair((n - m) / 2 - j)) * Math.Pow(r,n-2*j);
                    else
                        ans += stair(n - j) / (stair(j) * stair((n + m) / 2 - j) * stair((n - m) / 2 - j)) * Math.Pow(r, n - 2 * j)*-1;
                }
                Console.WriteLine($"計算徑向多項式(radial polynomials) ..., r = {r} , n = {n} , m = {list[i]}");
                Console.WriteLine($"所求之徑向多項式為 = {ans}");
            }
            Console.WriteLine("計算完畢！");
            Console.Read();

        }
        static float stair(float val)
        {
            float ans = 1;
            for (int i = 1; i <= val; i++)
                ans *= i;
            return ans;
        }
    }
}
