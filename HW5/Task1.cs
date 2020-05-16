using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;
//б) с использованием регулярных выражений.
//Семенов Дмитрий
namespace HW5
{
    partial class Tasks
    {
        public static bool EngLetter(char ch)
        {
            if(ch>'A' && ch<'z')
            {
                return true;
            }
            return false;
        }
        public static bool CheckLogin(string str, out string error)
        {
            if(str.Length<2 || str.Length>9)
            {
                error = "Bad length";
                return false;
            }
            if(char.IsDigit(str[0]))
            {
                error = "First char must be letter";
                return false;
            }
            for(int i=0; i<str.Length; i++)
            {
                if(!char.IsDigit(str[i]))
                {
                    if(!EngLetter(str[i]))
                    {
                        error = "Only 0-9 and Aa-Zz";
                        return false;
                    }
                    
                }
            }
            error = "Login correct";
            return true;
        }
        public static bool CheckLoginReg(string str, out string error)
        {
            Regex regex = new Regex("^[a-z][a-z0-9]{1,8}$",RegexOptions.IgnoreCase);
            if(regex.IsMatch(str))
            {
                error = "Login correct";
                return true;
            }
            error = "Login incorect";
            return false;
            
        }
        public static void Task1()
        {
            bool flag = false;
            Console.WriteLine("Without regular");
            while (!flag)
            {
                Console.Write("Input new Login 2-9 symbols  ");
                flag = CheckLogin(Console.ReadLine(), out string error);
                Console.WriteLine(error);
            }
            Console.WriteLine("With regular");
            flag = false;
            while (!flag)
            {
                Console.Write("Input new Login 2-9 symbols  ");
                flag = CheckLoginReg(Console.ReadLine(), out string error);
                Console.WriteLine(error);
            }
        }
    }
}