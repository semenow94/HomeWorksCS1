using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

//Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); где m — масса тела в килограммах, h — рост в метрах
//Семенов Д.Ю.

namespace HomeWork1_2
{
    class Program
    {
        static void Main()
        {
            double imt, height, weight, height_m;

            Console.Write("Какой у вас рост? ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Какой у вас вес? ");
            weight = Convert.ToDouble(Console.ReadLine());
            height_m = height / 100;
            imt = weight / (height_m * height_m);
            Console.WriteLine("При росте {0}см и весе {1}кг, ваш ИМТ = {2:F}", height, weight, imt);
            ConsoleHelp.Pause();
        }
    }
}
