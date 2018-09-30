using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_104_4
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("請選擇操作項目:\n\t(1)輸入模型資料:\n\t(2)計算平均相似度:\n\t(3)顯示各資料相似度:\n");
                switch (input("請選擇："))
                {
                    case "1":
                        Func1();
                        break;
                    case "2":
                        Func2();
                        break;
                    case "3":
                        Func3();
                        break;
                }
            } while (input("繼續:請按1，結束:請按0:") == "1");
        }
        static void Func1()
        {

        }
        static void Func2()
        {

        }
        static void Func3()
        {

        }
        static string input(string str)
        {
            Console.Write(str);
            return Console.ReadLine();
        }
    }
}
