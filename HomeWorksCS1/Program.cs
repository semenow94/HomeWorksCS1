using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

//Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.
//а) используя склеивание;
//б) используя форматированный вывод;
//в) *используя вывод со знаком $
//Семенов Д.Ю.

namespace HomeWorksCS1
{
    class Program
    {
        static void Main()
        {
            string name, surname, str;
            int age, height, weight;
            Console.Write("Как вас зовут? ");
            name = Console.ReadLine();
            Console.Write("Привет, "+name+", а твоя фамилия? ");
            surname = Console.ReadLine();
            Console.Write(name + " " + surname + ", сколько тебе лет? ");
            str = Console.ReadLine();
            age = Convert.ToInt32(str);
            Console.Write(name + " " + surname + ", какой у тебя рост? ");
            str = Console.ReadLine();
            height = Convert.ToInt32(str);
            Console.Write(name + " " + surname + ", какой у тебя вес? ");
            str = Console.ReadLine();
            weight = Convert.ToInt32(str);
            Console.WriteLine(name + " " + surname + ", ваш возраст - "+age+" , рост - "+height+" , вес - "+weight);
            Console.WriteLine("{0} {1}, ваш возраст - {2} , рост - {3} , вес - {4:F}", name, surname, age, height, weight);
            Console.WriteLine($"{name} {surname}, ваш возраст - {age} , рост - {height} , вес - {weight}");
            ConsoleHelp.Pause();

        }
    }
}
