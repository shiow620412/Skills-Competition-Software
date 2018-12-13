using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionCup107_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int len = int.Parse(input[0]);
            int K = 0;
            string data = input[1];
            for(int i =0;i<=4;i++)
            {
                if( Math.Pow(2,i) >= len)
                {
                    K = i + 1;
                    break;
                }
            }
            string[] ans = new string[K + len + 1];
            ans[0] = "";
            int count = 0;
            for(int i =1;i< ans.Length;i++)
            {
                if (isPowerByTwo(i))
                    continue;
                ans[i] = data[count].ToString();
                count++;
            }
            Stack<int> xor = new Stack<int>();
            for(int i=1;i<ans.Length;i++)
            {
                if (ans[i] == "1")
                    xor.Push(i);
            }
            int verify = xor.Pop();
            while (xor.Count > 0)
            {
                verify = verify ^ xor.Pop();
            }
            string code = Convert.ToString(verify,2);
            count = code.Length-1;
            for(int i =1;i<ans.Length;i++)
            {
                if(ans[i] ==null)
                {
                    ans[i] = code[count].ToString();
                    count--;
                }
            }
            Console.Write(string.Join("", ans));
            Console.Read();
            
        }
        static bool isPowerByTwo(int val)
        {
            for(int i =0;i<= 10;i++)
            {
                if (Math.Pow(2, i) == val)
                    return true;
            }
            return false;
        }
    }
}
