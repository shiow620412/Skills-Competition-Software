using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace skills_105_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(ofd.FileName);
                textBox2.Clear();
                string[] str;
                if (textBox1.Text.Contains("(一)"))
                {
                    str = textBox1.Text.Replace("\r", "").Replace("\n", "").Split(new string[] { "/"," " }, StringSplitOptions.RemoveEmptyEntries);
                    for(int i =0;i< str.Length;i++)
                    {
                        if(!str[i].Contains("課程進度"))
                            textBox2.Text += str[i]+"\r\n";
                        else
                        {
                            string temp = str[i].Substring(0, str[i].IndexOf("("));
                            str[i] = str[i].Substring(str[i].IndexOf("(")).Replace("(","").Replace(")","");
                            textBox2.Text += temp + "\r\n";
                            textBox2.Text += str[i] + "\r\n";
                        }
                    }
                }

                else
                {
                    
                    str = textBox1.Text.Replace("\r", "").Replace("\n", "").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < str.Length; i++)
                    {

                        /* if (i + 1 < str.Length && Regex.IsMatch(str[i + 1], "[A-Za-z0-9,-]") && !Regex.IsMatch(str[i + 1], "[\u4e00-\u9fa5]") && (Regex.IsMatch(str[i], "[A-Za-z0-9,-]")| Regex.IsMatch(str[i], "[\u4e00-\u9fa5]")))
                         {
                             textBox2.Text += str[i] + " ";
                             continue;
                         }
                         if (str[i].IndexOf("??") != -1)
                             textBox2.Text += str[i].Replace("?", "") + "\r\n";
                         else
                             textBox2.Text += str[i] + "\r\n";*/
                        if (str[i].Contains("??"))
                            str[i] = str[i].Replace("?", "");
                        if (str[i].Contains("：："))
                            str[i] = str[i].Replace("：：", "：");
                        textBox2.Text += str[i]+" ";
                        if (i + 1 < str.Length && str[i + 1].Contains("："))
                            textBox2.Text += "\r\n";

                    }
                }

                
            }
        }
    }
}
