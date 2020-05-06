using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
//Предусмотреть методы сложения, вычитания, умножения и деления дробей.
//Написать программу, демонстрирующую все разработанные элементы класса.Достаточно решить 2 задачи.Все программы сделать в одном решении.
//** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
//ArgumentException("Знаменатель не может быть равен 0");
//Добавить упрощение дробей.
//Семенов Дмитрий
namespace HomeWork3
{
    public class Fractional
    {
        int numerator, denumerator;
        bool CreateFractional(string str)
        {
            string  num = "", denum = "";
            bool flag, num_f, denum_f;
            flag = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '/')
                {
                    flag = true;
                    continue;
                }
                if (flag)
                {
                    denum += str[i];
                }
                else
                {
                    num += str[i];
                }

            }
            num_f = int.TryParse(num, out numerator);
            if (num_f && numerator==0)
            {
                Console.WriteLine("Числитель введен не верно " + num);
                return false;
            }
            if (!num_f && num.Length>0)
            {
                Console.WriteLine("Числитель введен не верно " + num);
                return false;
            }
            denum_f = int.TryParse(denum, out denumerator);
            if (denumerator == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
            if (!denum_f && denum.Length>0)
            {
                Console.WriteLine("Знаменатель введен не верно " + denum);
                return false;
            }
            if(!flag)
            {
                Console.WriteLine("Вы не ввели разделитель / ");
                return false;
            }
            return true;

        }
        public Fractional()
        {
            string str;
            bool flag=false;
            while(!flag)
            {
                Console.Write("Введите дробное число, используя / ");
                str = Console.ReadLine();
                flag = CreateFractional(str);
            }
        }
        public Fractional(int i, int k)
        {
            numerator = i;
            denumerator = k;
        }
        public string Print()
        {
            string str;
            if (numerator==denumerator)
            {
                str = "1";
            }
            else
            {
                if (numerator == 0)
                {
                    str = "0";
                }
                else
                {
                    str = numerator + " / " + denumerator;
                }
            }
            return str;
        }
        public string Summ(Fractional fract)
        {
            int num, denum;
            if(this.denumerator==fract.denumerator)
            {
                num = this.numerator + fract.numerator;
                denum = this.denumerator;
            }
            else
            {
                num = this.numerator * fract.denumerator + fract.numerator * this.denumerator;
                denum = this.denumerator * fract.denumerator;
            }
            Fractional fractional = new Fractional(num, denum);
            fractional.Simplification();
            return fractional.Print();
        }
        public string Subtraction(Fractional fract)
        {
            int num, denum;
            if (this.denumerator == fract.denumerator)
            {
                num = this.numerator - fract.numerator;
                denum = this.denumerator;
            }
            else
            {
                num = this.numerator * fract.denumerator - fract.numerator * this.denumerator;
                denum = this.denumerator * fract.denumerator;
            }
            Fractional fractional = new Fractional(num, denum);
            fractional.Simplification();
            return fractional.Print();
        }
        public string Multiplication(Fractional fract)
        {
            int num, denum;
            num = this.numerator * fract.numerator;
            denum = this.denumerator * fract.denumerator;
            Fractional fractional = new Fractional(num, denum);
            fractional.Simplification();
            return fractional.Print();
        }
        public string Division(Fractional fract)
        {
            int num, denum;
            num = this.numerator * fract.denumerator;
            denum = this.denumerator * fract.numerator;
            Fractional fractional = new Fractional(num, denum);
            fractional.Simplification();
            return fractional.Print();
        }
        public void Simplification()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for(int i=2; i<10; i++)
                {
                    if(numerator%i==0 && denumerator%i==0)
                    {
                        numerator /= i;
                        denumerator /= i;
                        flag = true;
                    }
                }
            }
        }
    }
    partial class Tasks
    {
        public static void Task3()
        {
            Fractional fract = new Fractional();
            Fractional fract1 = new Fractional();
            Console.WriteLine(fract.Print() + "+" + fract1.Print() + " = " + fract.Summ(fract1));
            Console.WriteLine(fract.Print() + "-" + fract1.Print() + " = " + fract.Subtraction(fract1));
            Console.WriteLine(fract.Print() + "*" + fract1.Print() + " = " + fract.Multiplication(fract1));
            Console.WriteLine(fract.Print() + "/" + fract1.Print() + " = " + fract.Division(fract1));
            Fractional fract3 = new Fractional(5, 400);
            Fractional fract4 = new Fractional(5, 400);
            fract4.Simplification();
            Console.WriteLine("Упрощение " + fract3.Print() + " = " + fract4.Print());
        }
    }
}
