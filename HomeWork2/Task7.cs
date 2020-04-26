using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b);
//б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.
//Семенов Дмитрий
namespace HomeWork2
{
    partial class Tasks
    {
        static int SummNumbers(int a, int b)
        {
            int summ=a;
            if(a<b)
            {
                summ = a + SummNumbers(a + 1, b);
            }
            return summ;
        }
        static void PrintNumbers(int a, int b)
        {
            Console.WriteLine(a);
            if (a<b)
            {
                PrintNumbers(a+1, b);
            }
        }
        public static void Task7()
        {
            int a = 0;
            int b = 4;
            PrintNumbers(a, b);
            Console.WriteLine("Их сумма = "+SummNumbers(a, b));
        }
    }
}
