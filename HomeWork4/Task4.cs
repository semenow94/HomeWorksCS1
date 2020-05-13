using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//а) Реализовать класс для работы с двумерным массивом.Реализовать конструктор, заполняющий массив случайными числами.
//Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
//свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, 
//метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out) Не сделано
//* б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл. Не сделано
//Семенов Дмитрий
namespace HomeWork4
{
    partial class Tasks
    {
        public class DoubleArray
        {
            int[,] a;

            public DoubleArray(int x, int y)
            {
                a = new int[x, y];
                Random rand = new Random();
                for(int i=0; i<x; i++)
                {
                    for (int k = 0; k < y; k++)
                    {
                        a[i, k] = rand.Next(0, 100);
                    }
                }
            }
            public void Summ()
            {
                int summ = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        summ += a[i, k];
                    }
                }
                Console.WriteLine("Summa elementov massiva = " + summ);
            }
            public void SummMoreThan(int x)
            {
                int summ = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        if (a[i, k] > x)
                        {
                            summ += a[i, k];
                        }
                    }
                }
                Console.WriteLine("Summa elementov massiva>"+x+" = " + summ);
            }
            public int Max
            {
                get
                {
                    int max = a[0,0];
                    for (int i = 0; i < a.GetLength(0); i++)
                    {
                        for (int k = 0; k < a.GetLength(1); k++)
                        {
                            if (a[i, k] > max)
                            {
                                max = a[i, k];
                            }
                        }
                    }
                    return max;
                }
            }
            public int Min
            {
                get
                {
                    int min = a[0, 0];
                    for (int i = 0; i < a.GetLength(0); i++)
                    {
                        for (int k = 0; k < a.GetLength(1); k++)
                        {
                            if (a[i, k] < min)
                            {
                                min = a[i, k];
                            }
                        }
                    }
                    return min;
                }
            }
            public override string ToString()
            {
                string str="";
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        str += a[i, k] + " ";
                    }
                    str += "\n";
                }
                return str;
            }
        }
        public static void Task4()
        {
            DoubleArray arr = new DoubleArray(10, 5);
            Console.WriteLine(arr);
            arr.Summ();
            arr.SummMoreThan(50);
            Console.WriteLine("Max = " + arr.Max);
            Console.WriteLine("Min = " + arr.Min);
        }
    }
}
