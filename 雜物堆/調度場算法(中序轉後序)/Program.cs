using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace 調度場算法_中序轉後序_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入四則運算式：");
            string input = Console.ReadLine();
            Queue<string> postfix = new Queue<string>();
            Stack<string> opa = new Stack<string>();
            for(int i=0;i< input.Length;i++)
            {
                string temp = input[i].ToString();
                switch(temp)
                {
                    case "(":
                        opa.Push(temp);
                        break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        while (opa.Count > 0 && getPriority(opa.Peek()) >= getPriority(temp))
                        {
                            postfix.Enqueue(opa.Pop());
                        }
                        opa.Push(temp);
                        break;
                    case "^":                        
                        while( opa.Count>0 && getPriority(opa.Peek()) > getPriority(temp))
                        {
                            postfix.Enqueue(opa.Pop());
                        }
                        opa.Push(temp);
                        break;
                    case ")":
                        while (opa.Peek() != "(")
                            postfix.Enqueue(opa.Pop());
                        opa.Pop();
                        break;
                    default:
                        string num = temp;
                        i++;
                        for(;i<input.Length;i++)
                        {
                            if(isNum(input[i].ToString()))
                            {
                                num += input[i].ToString();
                            }
                            else { break; }
                        }
                        i--;
                        postfix.Enqueue(num);
                        break;
                }
            }
            while (opa.Count > 0)
                postfix.Enqueue(opa.Pop());
            if (postfix.Count(x => x == "(" | x == ")") > 0)
                Console.Write("Error");
            else
                while (postfix.Count > 0)
                    Console.Write(postfix.Dequeue());
            Console.Read();
        }
        static bool isNum(string s)
        {
            return Regex.IsMatch(s, "^[0-9.]+$");
        }
        static int getPriority(string s)
        {
            switch (s)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 0;                    
            }
        }
    }
}
