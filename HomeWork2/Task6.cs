using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000. 
//Хорошим называется число, которое делится на сумму своих цифр.
//Реализовать подсчет времени выполнения программы, используя структуру DateTime.
//Семенов Дмитрий

namespace HomeWork2
{
    partial class Tasks
    {
        static bool SearchGood(int i)
        {
            int k,n;
            n = i;
            int summ=0;
            do
            {
                k = i % 10;
                if (k > 0)
                {
                    summ += k;
                }
                i /= 10;
            }
            while (i != 0);

            if(n%summ==0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void Task6()
        {
            DateTime dateTime1 = DateTime.Now;
            int k = 0;
            for (int i = 1; i <= 1000000000; i++)
            {
                if (SearchGood(i))
                {
                    k++;
                }
            }
            Console.WriteLine("От одного до миллиарда {0} хороших чисел", k);
            DateTime dateTime2 = DateTime.Now;
            TimeSpan timeSpan = dateTime2 - dateTime1;
            Console.WriteLine("Выполнено за {0} секунд", timeSpan.TotalSeconds);
        }
    }
}
