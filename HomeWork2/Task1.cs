using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Написать метод, возвращающий минимальное из трех чисел.
//Семенов Дмитрий

namespace HomeWork2
{
    partial class Tasks
    {
        static int MinOfThree(int a, int b, int c)
        {
            if (b<=a && b<=c)
            {
                return b;
            }else if(c<=a)
            {
                return c;
            }
            return a;
        }
        public static void Task1()
        {
            int a, b, c;
            a = 5;
            b = 1;
            c = 6;
            Console.WriteLine("Min of {0} , {1} , {2} is {3}", a, b, c, MinOfThree(a, b, c));
        }
    }
}
