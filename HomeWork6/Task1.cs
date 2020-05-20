using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double, double). Продемонстрировать работу на функции с функцией a* x^2 и функцией a* sin(x).
//Семенов Дмитрий
namespace HomeWork6
{
    public delegate double Fun(double x);//double(double)
    public delegate double Fun2(double a, double x);//double(double,double)
    partial class Tasks
    {
        public static void Table2(Fun2 F, double a, double x, double b, double h)
        {

            Console.WriteLine("----- A ----- X ----- Y -----");
            while (a <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} ", a, x, F?.Invoke(a,x));
                double x1 = x+h;
                while (x1 <= b)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} ", a, x1, F?.Invoke(a, x1));
                    x1 += h;
                }
                a += h;
            }

            Console.WriteLine("-----------------------------");
        }
        public static double FuncAX2(double a, double x)
        {
            return a * Math.Pow(x, 2);
        }
        public static double FuncASinX(double a, double x)
        {
            return a * Math.Sin(x);
        }
        public static void Table(Fun F, double a, double b, double h)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (a <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", a, F?.Invoke(a) /*F(a)*/);
                a += h;
            }
            Console.WriteLine("---------------------");
        }

        public static double MyFunc(double x)//double(double)
        {
            return x * x * x;
        }

        public static double MyFunc2(double x)
        {
            return Math.Cos(Math.Log(x));
        }
        public static void Task1()
        {
            int a = 4;
            int b = 2;
            Fun fun = new Fun(Math.Atan);
            Table(fun, a, b, 1);
            Table(new Fun(Math.Atan), -4, 4, 1);
            Table(null, -4, 4, 1);
            //Создаем новый делегат и передаем ссылку на него в метод Table. 
            Console.WriteLine("Таблица функции MyFunc:");
            Table(new Fun(MyFunc), -2, 2, 1);//Параметры функции и тип возвращаемого значения, должны совпадать с делегатом
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            Table(MyFunc, -2, 2, 1);//Упрощение(c C# 2.0). Делегат создается автоматически. 
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, -2, 2, 1);//Можно передавать уже созданные функции
            Console.WriteLine("Таблица функции x^2:");
            //Упрощение(с C# 2.0). Использование анонимного метода
            Fun2 am = delegate (double x, double y)
            {
                return x * y;
            };
            Table(
                delegate (double x)
                {
                    return x * x;
                }, 0, 3, 0.5);

            Table(
                x => x * x,

                0, 3, 0.5
                );
            Console.WriteLine("y=a*x^2");
            Table2(FuncAX2, 1, 1, 4, 1);
            Console.WriteLine("y=a*sin(x)");
            Table2(FuncASinX, 1, 1, 4, 1);
            Console.ReadKey();
        }
    }
}
