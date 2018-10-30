using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace skills_103_4
{
    class Program
    {
        class Sign
        {
            public string Class;
            public string SchoolNumber;
            public string Name;
            public string Gender;
            public string Project;
            public bool team = false;
            private string[] teamRace = new string[] { "一顆球的距離", "天旋地轉", "滾大球袋鼠跳", "牽手同心" };
            public Sign(string s)
            {
                string[] temp = s.Split(' ');
                Class = temp[0];
                SchoolNumber = temp[1];
                Name = temp[2];
                Gender = temp[3];
                Project = temp[4];
                for (int i = 0; i < teamRace.Length; i++)
                {
                    if (Project == teamRace[i])
                        team = true;                   
                }
            }
            static List<Sign> input = new List<Sign>();
            static void Main(string[] args)
            {
                do
                {
                    switch (read("請選擇操作項目：\r\n\t(1)批次輸入：\r\n\t(2)選手查詢：\r\n\t(3)刪除：\r\n\t(4)逐筆輸入：\r\n\t(5)顯示所有資料：\r\n請選擇："))
                    {
                        case "1":
                            fun_批次輸入();
                            break;
                        case "2":
                            fun_選手查詢();
                            break;
                        case "3":
                            fun_刪除();
                            break;
                        case "4":
                            fun_逐筆輸入();
                            break;
                        case "5":
                            fun_顯示所有資料();
                            break;
                    }
                } while (read("繼續：請按1，結束：請按0：") == "1");
            }
            static void fun_批次輸入()
            {
                Console.WriteLine("批次輸入");
                string[] inputData = File.ReadAllLines(read("請輸入檔名(.txt):"), Encoding.Default);
                for (int i = 0; i < inputData.Length; i++)
                {
                    input.Add(new Sign(inputData[i]));
                }

            }
            static void fun_選手查詢()
            {
                Console.WriteLine("選手查詢");
                string[] condition = read("請輸入班級、學號、姓名:").Split(' ');
                input.ForEach(x =>
                {
                    if (x.Class == condition[0] && x.SchoolNumber == condition[1] && x.Name == condition[2])
                    {
                        Console.WriteLine($"{x.Class} {x.SchoolNumber} {x.Name} {x.Gender} {x.Project}");
                    }
                });
            }
            static void fun_刪除()
            {
                Console.WriteLine("刪除資料");
                string[] condition = read("請輸入班級、學號、姓名及報名項目:").Split(' ');
                input.ForEach(x =>
                {
                    if (x.Class == condition[0] && x.SchoolNumber == condition[1] && x.Name == condition[2] && x.Project == condition[3])
                    {
                        Console.WriteLine($"被刪除的選手資料:{x.Class} {x.SchoolNumber} {x.Name} {x.Gender} {x.Project}");                        
                    }
                });
                input.RemoveAll(x => x.Class == condition[0] && x.SchoolNumber == condition[1] && x.Name == condition[2] && x.Project == condition[3]);
            }
            static void fun_逐筆輸入()
            {
                Console.WriteLine("逐筆輸入");
                string[] condition = read("請輸入班級、學號、姓名及性別:").Split(' ');
                Console.WriteLine("報名項目:\r\n a :大隊接力\r\n b :一顆球的距離\r\n c :天旋地轉\r\n d :滾大球袋鼠跳\r\n e :牽手同心\r\n f :100公尺\r\n g :400公尺\r\n h :800公尺\r\n i :跳高");
                string project = "";
                bool team = false;
                switch (read("請選擇:"))
                {
                    case "a":
                        project = "大隊接力";
                        break;
                    case "b":
                        project = "一顆球的距離";
                        team = true;
                        break;
                    case "c":
                        project = "天旋地轉";
                        team = true;
                        break;
                    case "d":
                        project = "滾大球袋鼠跳";
                        team = true;
                        break;
                    case "e":
                        project = "牽手同心";
                        team = true;
                        break;
                    case "f":
                        project = "100公尺";
                        break;
                    case "g":
                        project = "400公尺接力";
                        break;
                    case "h":
                        project = "800公尺";
                        break;
                    case "i":
                        project = "跳高";
                        break;
                }
                Console.WriteLine($"輸入班級:{condition[0]}、學號:{condition[1]}、姓名:{condition[2]}、性別:{condition[3]}、報名項目:{project}");
                input.ForEach(x =>
                {
                    if (x.Class == condition[0] && x.SchoolNumber == condition[1] && x.Name == condition[2] )
                    {
                        Console.WriteLine($"{x.Class} {x.SchoolNumber} {x.Name} {x.Gender} {x.Project}");
                    }
                });
                if (input.Count(x => x.SchoolNumber == condition[1] && x.team == !team) != 0)
                {
                    if (team)
                        Console.WriteLine("已報名團體賽，不能再報名個人賽!");
                    else
                        Console.WriteLine("已報名個人賽，不能再報名團體賽!");
                }
                else if (input.Count(x => x.SchoolNumber == condition[1] && x.team == team) > 2)
                {
                    if (team)
                        Console.WriteLine("已報名團體賽，不能再報名超過兩項!");
                    else
                        Console.WriteLine("已報名個人賽，不能再報名超過兩項!");
                }
                else
                {
                    Console.WriteLine("成功報名");
                    input.Add(new Sign($"{condition[0]} {condition[1]} {condition[2]} {condition[3]} {project}"));
                }
            }
            static void fun_顯示所有資料()
            {
                Console.WriteLine("班級、學號、姓名、性別、比賽項目");
                input.ForEach(x =>
                {
                    Console.WriteLine($"{x.Class} {x.SchoolNumber} {x.Name} {x.Gender} {x.Project}");
                });
            }
            static string read(string s)
            {
                Console.Write(s);
                return Console.ReadLine();
            }
        }
    }
}
