using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ConsoleHelp
    {
        public static void Pause()
        {
            Console.Write("Нажмите любую кнопку для выхода ");
            Console.ReadKey();
        }
    }
}
