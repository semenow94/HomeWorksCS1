using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Написать метод подсчета количества цифр числа.
//Семенов Дмитрий

namespace HomeWork2
{
    partial class Tasks
    {
        static int NumbersInInt(int i)
        {
            int k = 0;
            do
            {
                i /= 10;
                k++;
            }
            while (i > 0 || i < 0);
            return k;
        }
        public static void Task2()
        {
            Console.Write("Введите целое число ");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В числе {0} количество цифр = {1}", i, NumbersInInt(i));
        }
    }
}
