using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NCCU_CS_a021
{
    class Program
    {                
        static int a, b;
        static Stack<int>[] block;
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            block = new Stack<int>[count];
            for (int i = 0; i < count; i++)
            {
                block[i] = new Stack<int>();
                block[i].Push(i);
            }
            string[] cmd;
            string[] input = File.ReadAllLines("input.txt");
            for (int i = 0; i < input.Length; i++)
            {
                cmd = input[i].Split(' ');
                a = int.Parse(cmd[1]);
                b = int.Parse(cmd[3]);
                if (a == b)
                    continue;
                switch (cmd[0])
                {
                    case "move":
                        switch (cmd[2])
                        {
                            case "onto":
                                fun_mOnto();
                                break;
                            case "over":
                                fun_mOver();
                                break;
                        }
                        break;
                    case "pile":
                        switch (cmd[2])
                        {
                            case "onto":
                                fun_pOnto();
                                break;
                            case "over":
                                fun_pOver();
                                break;
                        }
                        break;
                }
             }
            
            for(int i =0;i<block.Length;i++)
            {
                Console.Write($"{i}: ");
                List<int> ls = block[i].ToList();
                ls.Reverse();
                ls.ForEach(x => Console.Write($"{x} "));
                Console.Write("\r\n");
            }
            Console.Read();
        }
        static void recover (int num)
        {
            if (block[num].Count == 0)
            {
                Stack<int> temp = findStack(num);
                while(temp.Peek() != num)
                {
                    block[temp.Peek()].Push(temp.Pop());
                }                
            }
        }
        static Stack<int> findStack(int num )
        {
            for(int i =0;i<block.Length;i++)
            {
                 if( block[i].Contains(num))
                {
                    return block[i];
                }
            }
            return new Stack<int>();
        }
        static void pushBlock(int num, int num2)
        {
            Stack<int> temp = findStack(num);
            
            Stack<int> temp2 = findStack(num2);
            if (temp == temp2)
                return;
            Stack<int> temp3 = new Stack<int>();
            while (temp.Peek() != num)
                temp3.Push(temp.Pop());
            temp2.Push(temp.Pop());
            while (temp3.Count > 0)
                temp2.Push(temp3.Pop());
        }
        static void fun_mOnto()
        {
            recover(a);
            recover(b);
            Stack<int> stack = findStack(a);
            stack.Pop();
            stack = findStack(b);
            stack.Push(a);
        }
        static void fun_mOver()
        {
            recover(a);
            Stack<int> stack = findStack(a);
            stack.Pop();
            stack = findStack(b);
            stack.Push(a);
        }
        static void fun_pOnto()
        {
            recover(b);
            Stack<int> stack = findStack(b);
            pushBlock(a, b);
        }
        static void fun_pOver()
        {
            pushBlock(a, b);
        }
    }
}
