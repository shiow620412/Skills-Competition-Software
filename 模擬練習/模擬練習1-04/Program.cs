using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模擬練習1_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入資料：");
            int G = 34943;
            string data = "";
            byte[] b = Encoding.ASCII.GetBytes(Console.ReadLine());
            for (int i = 0; i < b.Length; i++)
            {
                data += Convert.ToString(b[i], 2).PadLeft(8, '0');
            }
            data += "".PadLeft(16, '0');
            int ans = 0;
            for(int i =0;i<data.Length;i++)
            {
                ans = ans << 1;
                ans += int.Parse(data[i].ToString());
                if (ans > G)
                    ans -= G;   
            }
            Console.WriteLine(Convert.ToString(G - ans,16));
            Console.Read();
        }
    }
}
