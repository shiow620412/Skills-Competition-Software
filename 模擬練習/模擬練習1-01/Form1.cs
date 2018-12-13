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
namespace 模擬練習1_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        cmd[] com;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                string[] input = File.ReadAllLines(ofd.FileName);
                com = new cmd[input.Length];
                textBox1.Clear();
                for (int i = 0; i < input.Length; i++)
                {
                    textBox1.Text += input[i] + "\r\n";
                    com [i] = new cmd( Array.ConvertAll(input[i].Split('\t'), float.Parse) );
                }
            }
        }
        float[] weight;
        private void button1_Click(object sender, EventArgs e)
        {
            weight = new float[3];
            float n = float.Parse(textBox4.Text);
            float[] arr = Array.ConvertAll(textBox3.Text.Split(';'),float.Parse);
            weight[0] = arr[0];
            weight[1] = arr[1];
            weight[2] = arr[2];
            float error;
            do
            {
                error = 0;
                
                for (int i = 0; i < com.Length; i++)
                {
                    float val = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        val += com[i].command[j] * weight[j];
                    }
                    val = lorR(val);
                    if (val != com[i].Output)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            weight[j] = weight[j] + n * (com[i].Output - val) * com[i].command[j];
                        }
                       

                    }
                    error = error + 0.5f * (float)Math.Pow(Math.Abs(com[i].Output - val), 2);
                }
            } while (error != 0);
            textBox2.Text = $"{weight[0]};{weight[1]};{weight[2]}";
        }
            int lorR ( float val)
        {
            if (val >= 0)
                return 1;
            else
                return -1;
        }

       public class cmd
        {
            public float[] command;
            public float Output;
            public cmd(float[] input)
            {
                command = new float[3];
                command[0] = input[0];
                command[1] = input[1];
                command[2] = input[2];
                if(input.Length ==4)
                Output = input[3];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd testCmd = new cmd(new float[] { 1.0f, 1.0f, 1.0f });
            float val = 0;
            for (int i = 0; i < 3; i++)
            {
                val += testCmd.command[i] * weight[i];
            }
            label9.Text = lorR(val) == 1 ? "機器人向:1(左)" : "機器人向:-1(右)";
        }
    }
}
