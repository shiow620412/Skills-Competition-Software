using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模擬練習101_02
{
    class Program
    {
        static void Main(string[] args)
       {
            do
            {
                Console.WriteLine("輸入比值");
                double[,] pointer = new double[3, 3];
                double[] temp;
                for (int i = 0; i < 3; i++)
                    pointer[i, i] = 1;
                Console.Write("請輸入「專業能力」對「通識素養」的指標比值(輸入2個數值)：");
                temp = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
                temp[0] /= temp[1];
                pointer[0, 1] = temp[0];pointer[1, 0] = 1 / temp[0];
                Console.Write("請輸入「專業能力」對「合群性」的指標比值(輸入2個數值)：");
                temp = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
                temp[0] /= temp[1];
                pointer[0, 2] = temp[0]; pointer[2, 0] = 1 / temp[0];
                Console.Write("請輸入「通識素養」對「合群性」的指標比值(輸入2個數值)：");
                temp = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
                temp[0] /= temp[1];
                pointer[1, 2] = temp[0]; pointer[2, 1] = 1 / temp[0];
                Console.WriteLine("顯示比值矩陣：");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        Console.Write(" " + pointer[i, j].ToString("0.000"));
                    Console.WriteLine();
                }
                double[,] b = new double[3, 3];
                for(int i=0;i<3;i++)
                {
                    for(int j=0;j<3;j++)
                    {
                        b[i, j] = pointer[i, j] / (pointer[0, j] + pointer[1, j] + pointer[2, j]);
                    }
                }
                double[] weight = new double[3];
                for (int i = 0; i < 3; i++)
                    weight[i] = (b[i, 0] + b[i, 1] + b[i, 2]) / 3;
                Console.WriteLine($"顯示指標的權重: w1:{weight[0].ToString("0.000")}  w2:{weight[1].ToString("0.000")}  w3:{weight[2].ToString("0.000")}");
                double LundaMax=0;
                double[] sum = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    sum[i] = pointer[ 0,i] + pointer[1,i] + pointer[2, i];
                    LundaMax += sum[i] * weight[i];
                }
                double CR = (LundaMax- 3) / ((3 - 1) * 0.58);
                Console.WriteLine($"顯示最大特徵值 LundaMax={LundaMax.ToString("0.000")}");
                Console.Write($"顯示一致性比率 CR={CR.ToString("0.000")}。");
                if (CR < 0.1)
                    Console.Write("CR小於0.1，符合一致性。");
                Console.WriteLine("\r\n繼續否(y or n )");
            } while (Console.ReadLine().ToLower() == "y");
        }
    }
}
