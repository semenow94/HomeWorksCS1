using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

//Написать программу обмена значениями двух переменных.
//а) с использованием третьей переменной;
//б) * без использования третьей переменной.
//Семенов Д.Ю.

namespace HomeWork1_4
{
    class Program
    {
        static void Main()
        {
            int a, b, c;
            a = 1;
            b = 2;
            Console.WriteLine($"a={a}, b={b}");
            c = a;
            a = b;
            b = c;
            Console.WriteLine($"После обмена через третью переменную a={a}, b={b}");

            a = 5;
            b = 4;
            Console.WriteLine($"a={a}, b={b}");
            a += b;
            b = a - b;
            a -= b;
            Console.WriteLine($"После обмена без третьей переменной a={a}, b={b}");
            ConsoleHelp.Pause();
        }
    }
}
