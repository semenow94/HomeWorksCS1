using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

//а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
//б) * Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;
//Семенов Д.Ю.

namespace HomeWork1_3
{
    class Program
    {
        static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        static void Main()
        {
            double x1, x2, y1, y2, distance;
            Console.Write("Введите точку x1 ");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите точку y1 ");
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите точку x2 ");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите точку y2 ");
            y2 = Convert.ToDouble(Console.ReadLine());
            distance = Distance(x1, y1, x2, y2);
            Console.WriteLine($"Расстояние между точкой [{x1},{y1}] и точкой [{x2},{y2}] = {distance:F2}");
            ConsoleHelp.Pause();
        }
    }
}
