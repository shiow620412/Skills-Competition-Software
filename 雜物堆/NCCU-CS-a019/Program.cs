using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NCCU_CS_a019
{
    class Program
    {
        static List<int[]> ls;
        static bool[] book;
        static List<Stack<int>> ans;
        static Stack<int> temp = new Stack<int>();
        static void dfs()
        {
            for(int i =0;i < ls.Count;i++)
            {
                if(!book[i])
                {
                    if (temp.Count != 0)
                    {
                        bool compare = false;
                        int[] arr =ls[i];
                        int[] box =ls[temp.Peek()];
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (box[j] < arr[j])
                            {
                                compare = true;
                                break;
                            }
                        }
                        if (compare)
                            continue;
                    }
                    book[i] = true;
                    temp.Push(i);
                    dfs();
                    book[i] = false;
                    temp.Pop();
                }
            }
            
            ans.Add(new Stack<int>(new Stack<int>(temp)));
        }
        static void Main(string[] args)
        {
            Console.Write("輸入要匯入的檔案名稱(*.txt)：");
            string[] input = File.ReadAllLines(Console.ReadLine()+".txt");

            ls = new List<int[]>();
            book = new bool[input.Length];
            ans = new List<Stack<int>>();
            for (int i =0;i<input.Length;i++)
            {
                int[] arr = Array.ConvertAll(input[i].Split(' '), int.Parse);
                Array.Sort(arr);
                ls.Add(arr);
                book[i] = false;
                         
            }
            dfs();
            int len = 0;
            int index = 0;
            for(int i =0;i<ans.Count;i++)
            {
                if(len < ans[i].Count)
                {
                    len = ans[i].Count;
                    index = i;
                }
            }
            Stack<int> output;
            Console.Write(len);
            ans.ForEach(x =>
            {
                if (x.Count == len)
                {
                    output = x;
                    Console.WriteLine();
                    while (output.Count > 0)
                        Console.Write(output.Pop() + 1 + " ");
                }
            });
         
           
            Console.Read();
        }
    }
}
