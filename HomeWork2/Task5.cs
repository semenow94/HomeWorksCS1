using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
//б) * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
//Семенов Дмитрий

namespace HomeWork2
{
    partial class Tasks
    {
        public static void Task5()
        {
            double imt, weight_norm, need, height, weight, height_m;
            Console.Write("Какой у вас рост в см? ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Какой у вас вес? ");
            weight = Convert.ToDouble(Console.ReadLine());
            height_m = height / 100;
            imt = weight / (height_m * height_m);
            Console.WriteLine("При росте {0}см и весе {1}кг, ваш ИМТ = {2:F}", height, weight, imt);
            if(imt<18.5)
            {
                weight_norm=18.5* (height_m * height_m);
                need = weight_norm - weight;
                Console.WriteLine($"Ваш вес меньше нормы, для нормализации необходим вес {weight_norm:F}, т.е. необходимо набрать {need:F}");
            }else if(imt>25)
            {
                weight_norm = 25 * (height_m * height_m);
                need = weight - weight_norm;
                Console.WriteLine($"Ваш вес выше нормы, для нормализации необходим вес {weight_norm:F}, т.е. необходимо скинуть {need:F}");
            }
            else
            {
                Console.WriteLine("Ваш вес в норме");
            }

        }
    }
}
