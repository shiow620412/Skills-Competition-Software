using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NCCU_CS_a065
{
    class Program
    {
        static void Main(string[] args)
        {
            Country[] teamA=new Country[4],teamB = new Country[4];
            string[] input = Console.ReadLine().Split(' ');
            for(int i =0; i<4;i++)
            {
                teamA[i] = new Country(input[i]);
            }
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < 4; i++)
            {
                teamB[i] = new Country(input[i]);
            }
            string[] temp  = File.ReadAllLines("input.txt");
            
            for (int i = 0; i < temp.Length; i++)
            {
                input = temp[i].Split(' ');
                int scoreA = int.Parse(input[1]);
                int scoreB = int.Parse(input[2]);
                var query = from data in teamA where data.Name == input[0] select data;
                if (query.Count() > 0)
                {
                    Country cA = query.ToArray()[0];
                    Country cB = (from data in teamA where data.Name == input[3] select data).ToArray()[0];
                    cA.WinBall += scoreA;
                    cA.LoseBall += scoreB;
                    cB.WinBall += scoreB;
                    cB.LoseBall += scoreA;
                    if (scoreA > scoreB)
                        cA.Rank += 3;
                    else if (scoreA < scoreB)
                        cB.Rank += 3;
                    else if (scoreA == scoreB)
                    {
                        cA.Rank += 1;
                        cB.Rank += 1;
                    }
                }
                else
                {
                    Country cA = (from data in teamB where data.Name == input[0] select data).ToArray()[0];
                    Country cB = (from data in teamB where data.Name == input[3] select data).ToArray()[0];
                    cA.WinBall += scoreA;
                    cA.LoseBall += scoreB;
                    cB.WinBall += scoreB;
                    cB.LoseBall += scoreA;
                    if (scoreA > scoreB)
                        cA.Rank += 3;
                    else if (scoreA < scoreB)
                        cB.Rank += 3;
                    else if (scoreA == scoreB)
                    {
                        cA.Rank += 1;
                        cB.Rank += 1;
                    }
                }
            }
            List<string> winner = new List<string>();
            var q = from data in teamA orderby data.Rank  descending select data.Name;
           for(int i =1; i<=2;i++)
            {
                Console.WriteLine($"A{i} {q.ToArray()[i - 1]}");
                winner.Add(q.ToArray()[i - 1]);
            }
            q = from data in teamB orderby data.Rank descending select data.Name;
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"B{i} {q.ToArray()[i - 1]}");
                winner.Add(q.ToArray()[i - 1]);
            }
            List<Country> c = (teamA.Concat(teamB)).ToList();
            winner.ForEach(x =>
            {
                c.RemoveAll(y => y.Name == x);
            });
            q = (from data in c orderby data.Rank descending,data.WinBall  descending  , data.LoseBall ascending , data.Name ascending select data.Name) ;            
            string[] arr = q.ToArray();
            Console.WriteLine("BEST3 " + arr[0]);


            Console.ReadLine();
        }

         public class Country
        {
            public string Name;
            public int Rank;
            public int WinBall;
            public int LoseBall;
            public Country(string Name)
            {
                this.Name = Name;
            }
            
        }
    }
}
