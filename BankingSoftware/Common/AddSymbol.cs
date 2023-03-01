using System;
using System.Collections.Generic;

namespace BankingSoftware.Common;

public static class AddSymbol
{
    public static void AddBreakLine(int symbolLength = 80, string symbol = "-")
    {
        for (var i = 0; i < symbolLength; i++)
        {
            Console.Write(symbol);
        }
        Console.WriteLine("");
    }

    public static void AddBreakLines(int symbolLength = 80, int lineLength = 3, string symbol = "-")
    {
        for (int i = 0; i < lineLength; i++)
        {
            AddBreakLine(symbolLength, symbol);
        }
        
        Console.WriteLine("\n");
    }
}