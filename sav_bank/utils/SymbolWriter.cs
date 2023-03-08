using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.utils
{
    public class SymbolWriter
    {
        public static void WriteSymbol(int length  = 50, string symbol = "=")
        {
            for (var i = 0; i < length; i++)
                Console.Write(symbol);
            Console.WriteLine("");
        }
    }
}
