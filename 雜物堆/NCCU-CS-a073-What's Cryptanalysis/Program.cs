using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace NCCU_CS_a073
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            List<obj> ls = new List<obj>();
            for(int i =0;i<input.Length;i++)
            {
                var find = from data in ls where data.key == input[i].ToString() select data;
                if (find.Count() > 0)
                    find.ToList()[0].value++;
                else
                    ls.Add(new obj(input[i].ToString(), 1));
            }
            ls  = (from data in ls orderby data.value descending select data).ToList();
            List<int> times = new List<int>();
            ls.ForEach(x =>
            {
                if (times.Count(y => y == x.value) == 0)
                    times.Add(x.value);
            });
            for(int i =0;i< times.Count;i++)
            {
                var linq = from data in ls where data.value == times[i] orderby data.key ascending select data;
                linq.ToList().ForEach(x =>
                {
                    if(Regex.IsMatch(x.key,"[A-Z]"))
                        Console.WriteLine($"{x.key} {x.value}");
                });
            }
            Console.ReadLine();


        }
        class obj
        {
            public string key;
            public int value;
            public obj ()
            {

            }
            public obj ( string key,int value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
