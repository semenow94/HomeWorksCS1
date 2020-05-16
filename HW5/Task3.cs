using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.Регистр можно не учитывать:
//а) с использованием методов C#;
//б) * разработав собственный алгоритм.
//Например: badc являются перестановкой abcd.
//Семенов Дмитрий
namespace HW5
{
    partial class Tasks
    {
        public static void IsRebild(string str1, string str2)
        {
            string strA, strB;
            strA = string.Concat(str1.ToLower().OrderBy(x=>x));
            strB = string.Concat(str2.ToLower().OrderBy(x=>x));
            if(strA==strB)
            {
                Console.WriteLine($"String \"{str1}\" is rebilding of string \"{str2}\" ");
            }
            else
            {
                Console.WriteLine($"Strings \"{str1}\" and \"{str2}\" not rebildings");
            }
        }
        public static void IsRebildAlgo(string str1, string str2)
        {
            if(str1.Length==str2.Length)
            {
                char[] strA = str1.ToLower().ToCharArray();
                char[] strB = str2.ToLower().ToCharArray();
                Array.Sort(strA);
                Array.Sort(strB);
                for(int i=0; i<strA.Length; i++)
                {
                    if(strA[i]!=strB[i])
                    {
                        Console.WriteLine($"Strings \"{str1}\" and \"{str2}\" not rebildings");
                        return;
                    }
                }
                Console.WriteLine($"String \"{str1}\" is rebilding of string \"{str2}\" ");
            }
            else
            {
                Console.WriteLine($"Strings \"{str1}\" and \"{str2}\" not rebildings");
            }
            
            
        }
        public static void Task3()
        {
            string str1 = "abc1dy";
            string str2 = "Baydc";
            IsRebild(str1, str2);
            IsRebildAlgo(str1, str2);
        }
    }
}
