using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
//Требуется подсчитать сумму всех нечетных положительных чисел.Сами числа и сумму вывести на экран, используя tryParse;
//б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
//При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;
//    Семенов Дмитрий

namespace HomeWork3
{
    partial class Tasks
    {
        static void Error(string str)
        {
            Console.WriteLine(str + " не является целым числом");
        }
        public static void Task2()
        {
            string str;
            bool flag;
            int i, summ = 0;
            List<int> ints = new List<int>();
            List<int> intsN = new List<int>();

            Console.WriteLine("Вводите целые числа, либо 0, чтобы закончить ");
            do
            {
                
                str = Console.ReadLine();
                flag = int.TryParse(str, out i);
                if (flag)
                {
                    ints.Add(i);
                }
                else
                {
                    Error(str);
                    i++;
                }
                
            }
            while (i != 0);

            foreach (int k in ints)
            {
                if (k % 2 > 0 && k > 0)
                {
                    intsN.Add(k);
                }
            }

            foreach (int k in intsN)
            {
                summ += k;
            }
            Console.Write("Сумма нечетных положительных чисел ");
            foreach (int k in intsN)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine(" = " + summ);
        }
    }
}
