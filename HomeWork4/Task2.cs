using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
//Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, 
//метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов.
//В Main продемонстрировать работу класса.
//б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
//Семенов Дмитрий
namespace HomeWork4
{
    partial class Tasks
    {
        class OwnArray
        {
            int[] a;


            //свойство индексатор
            public int this[int index]
            {
                get
                {
                    return a[index];
                }
            }

            public int this[double index]
            {
                get
                {
                    return a[(int)index];
                }
            }

            public OwnArray(int length)
            {
                a = new int[length];
            }

            public OwnArray(int length, int start, int step) : this(length)
            {
                for(int i=0; i<a.Length; i++)
                {
                    a[i] = start + step * i;
                }
            }

            public OwnArray(string filename)
            {
                StreamReader sr = null;
                if (File.Exists(filename) == false)
                {
                    a = new int[10];
                    return;
                }
                int i = 0;
                try//попробуй
                {
                    sr = new StreamReader(filename);
                    string s = sr.ReadLine();//считали кол-во элементов
                    int length = int.Parse(s);
                    a = new int[length];
                    for (i = 0; i < length; i++)//считываем каждый элемент
                    {

                        s = sr.ReadLine();
                        try
                        {
                            a[i] = int.Parse(s);
                        }
                        catch (FormatException)
                        {
                            a[i] = 0;
                        }

                    }
                }
                catch (Exception exception)
                {
                    a = new int[10];
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    if (sr != null) sr.Close();
                    //sr?.Close();
                }

            }

            public void Inverse()
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] *=-1;
                }
            }
            public void Multi(int x)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] *= x;
                }
            }
            public void WriteToFile(string filename)
            {
                StreamWriter sw;
                sw = new StreamWriter(filename);
                sw.WriteLine(a.Length);
                foreach (int element in a)
                    sw.WriteLine(element.ToString());
                sw.Close();
            }
            public int SumEven
            {
                get
                {
                    int s = 0;
                    foreach (int element in a)
                    {
                        if (element % 2 == 0) s +=element;
                    }
                    return s;
                }
            }

            public int Sum
            {
                get
                {
                    int s = 0;
                    foreach (int element in a)
                    {
                        s += element;
                    }
                    return s;
                }
            }

            public int MaxCount
            {
                get
                {
                    int max = a[0];
                    foreach (int element in a)
                    {
                        if(element>max)
                        {
                            max = element;
                        }
                    }
                    return max;
                }
            }

            public void Delete()
            {
                a = null;
            }

            public override string ToString()
            {
                string s = "";
                //for (int i = 0; i < a.Length; i++)
                //    s = s + a[i].ToString() + " ";
                foreach (int element in a)//IEnumerable
                    s = s + element.ToString() + " ";
                return s;
            }
        }
        public static void Task2()
        {
            OwnArray a = new OwnArray(11, 1, 2);
            Console.WriteLine(a);
            Console.WriteLine("Summa " + a.Sum);
            Console.WriteLine("Max =" + a.MaxCount);
            a.Inverse();
            Console.WriteLine("Inverse " + a);
            Console.WriteLine("Max =" + a.MaxCount);
            a.Multi(2);
            Console.WriteLine("Multi " + a);
            string filename = "1.txt";
            a.WriteToFile(filename);
            OwnArray b = new OwnArray(filename);
            Console.WriteLine("Massiv iz faila " + b);

        }
    }
}
