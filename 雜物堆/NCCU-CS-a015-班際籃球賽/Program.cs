using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCCU_CS_a015
{
    class Program
    {
        static void Main(string[] args)
        {
            
                int input = int.Parse(Console.ReadLine());

                int ans = 0;
                while (input > 0)
                {
                    int temp = input;
                    while (temp > 1)
                    {
                        if (temp % 2 == 0)
                        {
                            temp -= 2;
                            ans++;
                        }
                        else
                        {
                            temp--;
                            ans++;
                        }
                    }
                    if (input % 2 == 0)
                        input /= 2;
                    else
                        input = (input - 1) / 2;
                }
                Console.WriteLine(ans);
                Console.Read();
            
        }
    }
}
