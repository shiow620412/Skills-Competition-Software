using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 模擬練習03_05
{
    class Program
    {
        class Student
        {
            public string Class;
            public string StudentID;
            public string Name;
            public string Gender;
            public List<string> Sign=new List<string>();

            public Student(string Class,string StudentID,string Name,string Gender,string Sign)
            {
                this.Class = Class;
                this.StudentID = StudentID;
                this.Name = Name;
                this.Gender = Gender;
                this.Sign.Add(Sign);
            }
        }
        static Hashtable ht = new Hashtable();
        static List<Student> std = new List<Student>();

        static void Main(string[] args)
        {
            ht.Add("a", "大隊接力");
            ht.Add("b", "一顆球的距離");
            ht.Add("c", "天旋地轉");
            ht.Add("d", "滾大球袋鼠跳");
            ht.Add("e", "牽手同心");
            ht.Add("f", "100公尺");
            ht.Add("g", "400公尺接力");
            ht.Add("h", "800公尺");
            ht.Add("i", "跳高");
            do
            {
                Console.Clear();
                Console.Write("請選擇操作項目:\n\t(1)批次輸入:\n\t(2)選手查詢:\n\t(3)刪除:\n\t(4)逐筆輸入:\n\t(5)顯示所有資料:\n請選擇：");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Fun1();
                        break;
                    case 2:
                        Fun2();
                        break;
                    case 3:
                        Fun3();
                        break;
                    case 4:
                        Fun4();
                        break;
                    case 5:
                        Fun5();
                        break;
                }
                Console.Write("繼續:請按1，結束:請按0:");
            } while (Console.ReadLine() == "1");
        }

        static void Fun1()
        {
            Console.WriteLine("批次輸入，");
            Console.Write("請輸入檔名:");
            string[] input = System.IO.File.ReadAllLines(Console.ReadLine(),Encoding.Default);
            string[] temp;
            for (int i = 0; i < input.Length; i++)
            {
                temp = input[i].Split(' ');
                var query = from data in std where data.StudentID == temp[1] select data;
                if (query.Count() > 0)
                    query.ToList()[0].Sign.Add(temp[4]);
                else
                    std.Add(new Student(temp[0], temp[1], temp[2], temp[3], temp[4]));
            }
        }
        static void search(string[] temp)
        {
            List<Student> query = (from data in std where data.Class == temp[0] && data.StudentID == temp[1] && data.Name == temp[2] select data).ToList();
            query.ForEach(x =>
            {
                x.Sign.ForEach(y =>
                {
                    Console.WriteLine($"{x.Class} {x.StudentID} {x.Name} {x.Gender} {y}");
                });
            });
        }
        static void Fun2()
        {
            Console.WriteLine("選手查詢，");
            Console.Write("請輸入 班級、學號、姓名：");
            string[] temp = Console.ReadLine().Split(' ');
            search(temp);


        }
        static void Fun3()
        {
            Console.WriteLine("刪除資料，");
            Console.Write("請輸入 班級、學號、姓名及報名項目：");
            string[] temp = Console.ReadLine().Split(' ');
            List<Student> query = (from data in std where data.Class == temp[0] && data.StudentID == temp[1] && data.Name == temp[2] select data).ToList() ;
            query[0].Sign.RemoveAll(x => x == temp[3]);
            Console.WriteLine($"被刪除的選手資料:{temp[0]} {temp[1]} {temp[2]} {temp[3]}");
        }
        static string[] book = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
        static void Fun4()
        {
            Console.WriteLine("逐筆輸入，");
            Console.Write("請輸入 班級、學號、姓名及性別：");
            string[] temp = Console.ReadLine().Split(' ');
            Console.WriteLine("報名項目:");
            foreach (DictionaryEntry item in ht)
                Console.WriteLine(item.Key + ":" + item.Value);
            Console.Write("請選擇:");
            string index = Console.ReadLine();
            Console.WriteLine($"輸入班級:{temp[0]}、學號:{temp[1]}、姓名:{temp[2]}、性別:{temp[3]}、報名項目:{ht[index].ToString()}");
            int countTeam = 0;
            int countPerson = 0;
            for (int i = 1; i < book.Length; i++)
            {
                if (i < 5)
                    countTeam += (from data in std where data.StudentID == temp[1] select data).Count();
                else
                    countPerson += (from data in std where data.StudentID == temp[1] select data).Count();
            }
            if (index == "f" | index == "g" | index == "h" | index == "i")
            {
                search(new string[] { temp[0], temp[1], temp[2] });
                if (countTeam > 0)
                {                   
                    Console.WriteLine("已報團體賽，不能再報名個人賽");
                }
                else if(countPerson>2)
                {
                    Console.WriteLine("已報個人賽，不能再報名超過2項");
                }
                else
                {
                    var query = from data in std where data.StudentID == temp[1] select data;
                    if (query.Count() > 0)
                        query.ToList()[0].Sign.Add(ht[index].ToString());
                    else
                        std.Add(new Student(temp[0], temp[1], temp[2], temp[3], ht[index].ToString()));

                    Console.WriteLine("報名成功");
                }
            }
            else
            {
                search(new string[] { temp[0], temp[1], temp[2] });
                if (countPerson > 0)
                {
                    Console.WriteLine("已報個人賽，不能再報名團體賽");
                }
                else if (countTeam > 2)
                {
                    Console.WriteLine("已報團體賽，不能再報名超過2項");
                }
                else
                {
                    var query = from data in std where data.StudentID == temp[1] select data;
                    if (query.Count() > 0)
                        query.ToList()[0].Sign.Add(ht[index].ToString());
                    else
                        std.Add(new Student(temp[0], temp[1], temp[2], temp[3], ht[index].ToString()));
                    Console.WriteLine("報名成功");
                }
            }
        }
        static void Fun5()
        {
            Console.WriteLine("顯示所有資料，");
            std.ForEach(x =>
            {
                x.Sign.ForEach(y =>
                {
                Console.WriteLine($"{x.Class} {x.StudentID} {x.Name} {x.Gender} {y}");
                });
            });
        }

    }
}
