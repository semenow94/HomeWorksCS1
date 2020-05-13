using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.Создайте структуру Account, содержащую Login и Password.
//Семенов Дмитрий
namespace HomeWork4
{
    partial class Tasks
    {
        public struct Account
        {
            public string Login { get; }
            public string Password { get; }
            public Account(string login, string password)
            {
                this.Login = login;
                this.Password = password;
            }
        }
        static bool CheckPassword(string login, string pass, List<Account> acc)
        {
            bool flag = false;
            foreach(Account a in acc)
            {
                if (login == a.Login && pass == a.Password)
                {
                    return true;
                }
            }
            return flag;
        }
        public static void CheckAccs(string filename, List<Account> acc)
        {
            string str;
            string log;
            string pass;

            StreamReader sr = new StreamReader(filename);
            bool flag = true;
            bool flag2;
            while(flag)
            {
                log = "";
                pass = "";
                flag2 = true;
                str = sr.ReadLine();
                if (str != null)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if(flag2)
                        {
                            if(str[i]==' ')
                            {
                                flag2 = false;
                            }
                            else
                            {
                                log += str[i];
                            }                            
                        }
                        else
                        {
                            if (str[i] != ' ')
                            {
                                pass += str[i];
                            }
                        }
                    }
                    acc.Add(new Account(log, pass));
                }
                else
                {
                    flag = false;
                }
            }            
            sr.Close();
        }
        public static void Task3()
        {
            string filename = "logs.txt";
            string login, pass;
            int i = 0;
            bool check;
            List < Account > acc= new List<Account>();
            CheckAccs(filename, acc);
            do
            {
                if (i > 0)
                {
                    Console.WriteLine("Логин или пароль не верен, попробуйте еще раз. Осталось попыток " + (3 - i));
                }
                Console.Write("Введите логин ");
                login = Console.ReadLine();
                Console.Write("Введите пароль ");
                pass = Console.ReadLine();
                check = CheckPassword(login, pass, acc);
                i++;
            } while (i < 3 && !check);
            if (check)
            {
                Console.WriteLine("Логин-пароль верен");
            }
            else
            {
                Console.WriteLine("Ваши попытки закончились, попоробуйте позже");
            }
        }
    }
}
