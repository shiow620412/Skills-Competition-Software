using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
namespace LionCup107_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> postfix = new Queue<string>();
            Stack<string> opa = new Stack<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string temp = input[i].ToString();
                switch (temp)
                {
                    case "(":
                        opa.Push(temp);
                        break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        while (opa.Count > 0 && getPriority(opa.Peek()) >= getPriority(temp))
                            postfix.Enqueue(opa.Pop());
                        opa.Push(temp);
                        break;
                    case "^":
                        while (opa.Count > 0 && getPriority(opa.Peek()) > getPriority(temp))
                            postfix.Enqueue(opa.Pop());
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
                        for (; i < input.Length; i++)
                        {
                            if (isNum(input[i].ToString()))
                                num += input[i].ToString();
                            else
                                break;
                        }
                        i--;
                        postfix.Enqueue(num);
                        break;
                }
            }
            while (opa.Count > 0)
                postfix.Enqueue(opa.Pop());
            if (postfix.Count(x => x =="("|x==")")>0)
            {
                Console.Write("N/A");
                Console.Read();
                return;
            }
            Stack<double> calcNum = new Stack<double>();            
            while(postfix.Count>0)
            {
                string s = postfix.Dequeue();
                if (isNum(s))
                    calcNum.Push(double.Parse(s));
                else
                {
                    calcNum.Push(calc(s, calcNum.Pop(), calcNum.Pop()));
                }
            }
            Console.Write($"Ans：{Math.Round(calcNum.Pop(),2,MidpointRounding.AwayFromZero)}");
            Console.Read();
        }
        static double calc ( string s , double a , double b)
        {
            switch( s)
            {
                case "+":
                    return a + b;
                case "-":
                    return b- a;
                case "*":
                    return a * b;
                case "/":
                    return b / a;
                case "^":
                    return Math.Pow(b,a);
            }
            return 0;
        }
        static bool isNum(string s) { return Regex.IsMatch(s, "^[0-9.]+$"); }
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
