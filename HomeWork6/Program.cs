﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Семенов Дмитрий
namespace HomeWork6
{
    class Program
    {
        static int Menu()
        {
            int i;
            do
            {
                Console.WriteLine("1 - Task1 ");
                Console.WriteLine("2 - Task2 ");
                Console.WriteLine("3 - Task3 ");
                Console.WriteLine("0 - Exit ");
                i = Convert.ToInt32(Console.ReadLine());
            }
            while (i < 0 || i > 3);
            return i;
        }
        static void Main()
        {
            int i;
            do
            {
                i = Menu();
                Console.WriteLine();
                Console.WriteLine("****************************************************************");
                switch (i)
                {
                    case 1:
                        Tasks.Task1();
                        break;
                    case 2:
                        Tasks.Task2();
                        break;
                    case 3:
                        Tasks.Task3();
                        break;
                    case 0:
                        Console.WriteLine("GoodBye!");
                        break;
                }
                Console.WriteLine("****************************************************************");
                Console.WriteLine();
            } while (i != 0);
            Console.ReadLine();
        }
    }
}
