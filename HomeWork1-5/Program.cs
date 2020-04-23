using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

//а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
//б) Сделать задание, только вывод организуйте в центре экрана
//в) * Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)
//Семенов Д.Ю.

namespace HomeWork1_5
{
    class Program
    {
        static void PrintInCenter(string str, int y)
        {
            int x;
            x = Console.WindowWidth / 2 - str.Length / 2;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }
        static void Main()
        {
            string name, surname, city;
            name = "Дмитрий";
            surname = "Семенов";
            city = "Наро-Фоминск";
            Console.WindowWidth = 50;
            Console.WindowHeight = 20;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            //Можно было рассчитать и позицию по высоте через массив и выводить пробегая по элементам массива, но мен лень =)
            PrintInCenter(name, 9);
            PrintInCenter(surname, 10);
            PrintInCenter(city, 11);
            ConsoleHelp.Pause();
        }
    }
}
