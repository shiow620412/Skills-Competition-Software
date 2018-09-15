using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_106_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("日期系列");
            double[] date = Array.ConvertAll(Console.ReadLine().Split(' '), x => double.Parse(x));
            Console.WriteLine("價格系列");
            double[] price = Array.ConvertAll(Console.ReadLine().Split(' '), x => double.Parse(x));
            double[] outPrice = new double[price.Length];
            int N = 10;
            double[] m = new double[date.Length];
            for (int i = N-1; i <date.Length;i++)
            {
                
                double xbar = 0, ybar = 0;
                for(int j = 0; j<N;j++)
                {
                    xbar += date[i - j]/10;
                    ybar += price[i - j]/10;
                }
                double b = 0, a = 0, up = 0, down = 0;
                for (int j = 0; j < N; j++)
                {
                    up += (date[i - j] - xbar) * (price[i - j] - ybar);
                    down += (date[i - j] - xbar) * (date[i - j] - xbar);
                }
                b = up / down;
                a = ybar - b * xbar;
                m[i] = b;
                if (i + 1 < date.Length)
                    outPrice[i + 1] = a + b * date[i + 1];
            }
            Console.WriteLine("直線斜率：");
            Console.WriteLine(String.Join(" ", Array.ConvertAll(m, x => x.ToString("0.0").PadLeft(4,' '))));
            Console.WriteLine("價格預測：");
            Console.WriteLine(String.Join(" ", Array.ConvertAll(outPrice, x => x.ToString("0.0").PadLeft(4,' '))));
            Console.ReadLine();
        }
    }
}
