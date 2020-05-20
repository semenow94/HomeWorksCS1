using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
//а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
//б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
//в) * Переделайте функцию Load, чтобы она возвращала массив считанных значений.Пусть она
//возвращает минимум через параметр.
//Семенов Дмитрий

namespace HomeWork6
{
    public delegate double Func(double x);
    partial class Tasks
    {
        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F1(double x)
        {
            return x * x;
        }
        public static double F2(double x)
        {
            return -x * -x * -x;
        }
        public static void SaveFunc(string fileName, Func foo, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(foo(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double [] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            int len = (int)fs.Length / sizeof(double);
            double[] mass = new double[len];
            for (int i = 0; i < len; i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                mass[i] = d;
                Console.Write("{0:0.0000} ",d);
                if (d < min) min = d;
            }
            Console.WriteLine();
            bw.Close();
            fs.Close();
            return mass;
        }
        public static void CheckParams(out double start, out double end, out double step)
        {
            Console.Write("Input X start ");
            double.TryParse(Console.ReadLine(), out start);
            Console.Write("Input X end ");
            double.TryParse(Console.ReadLine(), out end);
            Console.Write("Input X step ");
            double.TryParse(Console.ReadLine(), out step);
            Console.WriteLine();
        }

        public static void Task2()
        {
            int i;
            double[] mass;
            do
            {
                Console.WriteLine("Choose func");
                Console.WriteLine("1 - x^2-50*x+10 ");
                Console.WriteLine("2 - x^2 ");
                Console.WriteLine("3 - -x^3 ");
                i = Convert.ToInt32(Console.ReadLine());
            }
            while (i < 0 || i > 3);
            Func[] foo = { F, F1, F2 };
            CheckParams(out double start, out double end, out double step);
            SaveFunc("data.txt", foo[i-1], start, end, step);
            mass = Load("data.txt", out double min);
            Console.WriteLine("Min is " + min);
        }
    }
}
