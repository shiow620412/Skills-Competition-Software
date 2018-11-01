using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skills_101_2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            { 
                float[,] arr = new float[3, 3];
                arr[0, 0] = 1; arr[1, 1] = 1; arr[2, 2] = 1;
                Console.WriteLine("輸入比值");
                Console.Write("請輸入【專業能力】對【通識素養】的指標比值(輸入2個數值):");
                float[] input = Array.ConvertAll(Console.ReadLine().Split(' '), float.Parse);
                if (input[0] == 1)
                    input[0] /= input[1];
                arr[1, 0] = input[0];
                arr[0, 1] = 1 / arr[1, 0];
                Console.Write("請輸入【專業能力】對【合群性】的指標比值(輸入2個數值):");
                input = Array.ConvertAll(Console.ReadLine().Split(' '), float.Parse);
                if (input[0] == 1)
                    input[0] /= input[1];
                arr[2, 0] = input[0];
                arr[0, 2] = 1 / arr[2, 0];
                Console.Write("請輸入【通識素養】對【合群性】的指標比值(輸入2個數值):");
                input = Array.ConvertAll(Console.ReadLine().Split(' '), float.Parse);
                if (input[0] == 1)
                    input[0] /= input[1];
                arr[2, 1] = input[0];
                arr[1, 2] = 1 / arr[2, 1];
                Console.WriteLine("顯示比值矩陣");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(" " + arr[j, i].ToString("0.000"));
                    }
                    Console.Write("\r\n");
                }
                float[,] arrb = new float[3, 3];
                float[] a = new float[3];
                for (int i = 0; i < 3; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        sum += arr[i,j];
                    }
                    a[i] = sum;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        arrb[i,j] = arr[j,i] / a[j];
                    }
                }
                float[] w = new float[3];
                Console.Write("顯示指標的權重:");
                for (int i = 0; i < 3; i++)
                {
                    w[i] = (arrb[i, 0] + arrb[i, 1] + arrb[i, 2]) / 3;
                    Console.Write($"{i}1:{w[i].ToString("0.0000") + " "}");
                }
                Console.Write("\r\n");
                float maxSpecial = 0;
                float[] sumA = new float[3];
                for (int i = 0; i < 3; i++)
                {
                    sumA[i] = arr[i, 0] + arr[i, 1] + arr[i, 2];
                    maxSpecial += sumA[i] * w[i];
                }
                double CR = (maxSpecial - 3) / (1.16);
                Console.WriteLine($"顯示最大特徵值 LundaMax={maxSpecial.ToString("0.000")}");
                Console.WriteLine($"顯示一致性比率 CR={CR.ToString("0.000")}。CR小於0.1，符合一制性。");
                Console.WriteLine("繼續否?(Y or N)");
            }while (Console.ReadLine().ToUpper() == "Y") ;
        }
    }
}
