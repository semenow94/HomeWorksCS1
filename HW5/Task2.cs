using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

//Разработать класс Message, содержащий следующие статические методы для обработки
//текста:
//а) Вывести только те слова сообщения, которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//Продемонстрируйте работу программы на текстовом файле с вашей программой.
//Семенов Дмитрий

namespace HW5
{
    partial class Tasks
    {
        public class Message
        {
            public static string ReadMessage(string filename)
            {
                string str;
                str = File.ReadAllText(filename);
                return str;
            }
            public static void PrintShorter(string filename, int symbols)
            {
                string str = Message.ReadMessage(filename);
                string pattern = $"\\b([а-яa-z0-9]{{1,{symbols}}})\\b";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matchCollection = regex.Matches(str);
                Console.WriteLine("Words where symbols shorter");
                foreach(Match a in matchCollection)
                {
                        Console.Write(a.Value+" ");
                }
                Console.WriteLine();
            }
            public static string BiggestWord(string filename)
            {
                string str = Message.ReadMessage(filename);
                string maxWord = "";
                string pattern = $"\\b([а-яa-z0-9]*)\\b";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matchCollection = regex.Matches(str);
                foreach (Match a in matchCollection)
                {
                    if(a.Length>maxWord.Length)
                    {
                        maxWord = a.Value;
                    }
                }
                return maxWord;
            }
            public static void DeleteWhereLastSymbolIs(string filename, char symbol)
            {
                string str = Message.ReadMessage(filename);
                string pattern = $"\\b([а-яa-z0-9]*[{symbol}])\\b";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                str=regex.Replace(str, string.Empty);
                Console.WriteLine("Delete Where LastSymbol Is");
                Console.WriteLine(str);
            }
            public static StringBuilder TextWithBiggestWords(string filename)
            {
                string big = BiggestWord(filename);
                string str = Message.ReadMessage(filename);
                string pattern = $"\\b([а-яa-z0-9]{{{big.Length},}})\\b";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matchCollection = regex.Matches(str);
                Console.WriteLine("Text with biggest words");
                StringBuilder s = new StringBuilder();
                foreach (Match a in matchCollection)
                {
                    s.Append($"{a.Value} ");
                }
                return s;
            }
        }
        public static void Task2()
        {
            string filename = "text.txt";
            Console.WriteLine("Original text ");
            Console.WriteLine(Message.ReadMessage(filename));
            Console.WriteLine();
            Message.PrintShorter(filename, 5);
            Console.WriteLine();
            Message.DeleteWhereLastSymbolIs(filename, 'и');
            Console.WriteLine();
            Console.WriteLine("Biggest word is "+Message.BiggestWord(filename));
            Console.WriteLine();
            Console.WriteLine(Message.TextWithBiggestWords(filename));
        }
    }
}