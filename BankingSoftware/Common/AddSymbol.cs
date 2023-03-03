using System;

namespace BankingSoftware.Common;

public static class AddSymbol
{
    public static void AddBreakLine(int symbolLength = 80, string symbol = "-")
    {
        for (var i = 0; i < symbolLength; i++) 
            Console.Write(symbol);
        
        Console.WriteLine("");
    }

    public static void AddBreakLines(int symbolLength = 80, int lineLength = 3, string symbol = "-")
    {
        for (var k = 0; k < lineLength; k++) 
            AddBreakLine(symbolLength, symbol);

        Console.WriteLine("\n");
    }
}