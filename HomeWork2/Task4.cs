using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Реализовать метод проверки логина и пароля.На вход подается логин и пароль.
//На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
//Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
//С помощью цикла do while ограничить ввод пароля тремя попытками.
//Семенов Дмитрий

namespace HomeWork2
{
    partial class Tasks
    {
        static bool CheckPassword(string login, string pass)
        {
            if (login == "root" && pass == "GeekBrains")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Task4()
        {
            string login, pass;
            int i = 0;
            bool check;
            do
            {
                if(i>0)
                {
                    Console.WriteLine("Логин или пароль не верен, попробуйте еще раз. Осталось попыток " + (3 - i));
                }
                Console.Write("Введите логин ");
                login = Console.ReadLine();
                Console.Write("Введите пароль ");
                pass = Console.ReadLine();
                check = CheckPassword(login, pass);
                i++;
            } while (i < 3 && !check);
            if(check)
            {
                Console.WriteLine("Логин-пароль верен");
            }else
            {
                Console.WriteLine("Ваши попытки закончились, попоробуйте позже");
            }
            
        }
    }
}
