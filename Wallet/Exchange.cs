using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet
{
    public static class Exchange
    {
        public static double Sum { get; set; }
        public static DateTime Date { get; set; }
        public static string Description { get; set; }
        public static string Type { get; set; }
        public static int Index { get; set; } = -1;

        public static int Edit { get; set; }
    }
}
