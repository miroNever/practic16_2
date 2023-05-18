using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Пркатика_18_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                int num;
                if (int.TryParse(textBox1.Text, out num))
                {
                    if (num > 0 && num <= 100)
                    {
                        StreamWriter sw = File.AppendText("filenum.txt");
                        sw.Write(num + "\n");
                        sw.Close();
                        MessageBox.Show("Число успешно записано в файл");
                    }
                    else
                    {
                        MessageBox.Show("Число должно быть в диапозоне от 1 до 100");
                    }
                }
                else
                {
                    MessageBox.Show("Введённая строка не является числом");
                }
            }
            else
            {
                MessageBox.Show("Строка не заполнена");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0;
            if (textBox2.Text != String.Empty && textBox3.Text != String.Empty)
            {
                if (int.TryParse(textBox2.Text, out a) && int.TryParse(textBox3.Text, out b))
                {
                    if (a > 0 && a <= 100 && b > 0 && b <= 100)
                    {
                        if (a < b)
                        {
                            Queue<int> FromAToB = new Queue<int>();
                            Queue<int> LessThenA = new Queue<int>();
                            Queue<int> MoreThenB = new Queue<int>();
                            StreamReader sr = File.OpenText("filenum.txt");
                            int number;
                            while (!sr.EndOfStream)
                            {
                                number = int.Parse(sr.ReadLine());
                                if (number < a)
                                    LessThenA.Enqueue(number);
                                else if (number > b)
                                    MoreThenB.Enqueue(number);
                                else if(number > a && number < b)
                                    FromAToB.Enqueue(number);
                            }
                            listBox1.Items.Add("Числа от а до b \n");
                            for (int i = 0; i < FromAToB.Count; i++)
                            {
                                listBox1.Items.Add(FromAToB.Dequeue());
                            }
                            listBox1.Items.Add("Числа меньше а \n");
                            for (int i = 0; i < LessThenA.Count; i++)
                            {
                                listBox1.Items.Add(LessThenA.Dequeue());
                            }
                            listBox1.Items.Add("Числа больше b \n");
                            for (int i = 0; i < MoreThenB.Count; i++)
                            {
                                listBox1.Items.Add(MoreThenB.Dequeue());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Первое число диапозона не может быть больше второго");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Чиса должны быть в диапозоне от 1 до 100");
                    }
                }
                else
                {
                    MessageBox.Show("Введенные строки не являются числом");
                }
            }
            else
            {
                MessageBox.Show("Строки не заполнены");
            }


        }
    }
}
