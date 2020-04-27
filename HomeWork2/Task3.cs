using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
//Семенов Дмитрий

namespace HomeWork2
{
    partial class Tasks
    {
        public static void Task3()
        {
            int i, summ=0;
            List<int> ints = new List<int>();
            List<int> intsN = new List<int>();
            do
            {
                Console.Write("Введите положительное челое число или 0, чтобы закончить ");
                i = Convert.ToInt32(Console.ReadLine());
                if (i < 0) continue;
                ints.Add(i);
            }
            while (i != 0);

            foreach(int k in ints )
            {
                if(k%2>0)
                {
                    intsN.Add(k);
                }
            }

            foreach (int k in intsN)
            {
                summ += k;
            }
            Console.Write("Сумма нечетных чисел ");
            foreach (int k in intsN)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine(" = " + summ);
        }
    }
}
