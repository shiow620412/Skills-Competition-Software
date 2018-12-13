using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTUST_1314
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            byte[] b = Encoding.UTF8.GetBytes(input);
            Console.WriteLine("字串轉Byte (16進位表示 X0)");
            for(int i =0;i<b.Length;i++)                            
                Console.Write(b[i].ToString("X0") + "\t");
            Console.WriteLine("\r\n字串轉Byte (16進位表示 X1)");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i].ToString("X1") + "\t");
            Console.WriteLine("\r\n字串轉Byte (16進位表示 X2)");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i].ToString("X2") + "\t");
            Console.WriteLine("\r\n字串轉Byte (16進位表示 X3)");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i].ToString("X3") + "\t");
            Console.WriteLine("\r\n字串轉Byte (16進位表示 X4)");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i].ToString("X4") + "\t");
            Console.WriteLine("\r\n字串轉Byte (16進位表示 X5)");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i].ToString("X5") + "\t");
            Console.WriteLine("\r\n字串轉Byte (10進位表示)");
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i].ToString() + "\t");

            Console.Read();
        }
    }
}
