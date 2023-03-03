using System;
using BankingSoftware.Common;
using BankingSoftware.Modules;

namespace BankingSoftware;

internal class Program
{
    private const string userStoragePath =
        @"C:\Users\rexxr\Documents\projectss\CodeBenders\BankingSoftware\Storage\Users\";

    private const string accountStoragePath =
        @"C:\Users\rexxr\Documents\projectss\CodeBenders\BankingSoftware\Storage\Accounts\";

    public static void Auth(out string userLogin)
    {
        userLogin = "";
        Console.WriteLine("\nWelcome to our console banking app");
        AddSymbol.AddBreakLines(symbol: "*");

        Console.WriteLine("Please login or signup. \n");
        Console.WriteLine("Press 1 to login or 2 to signup");
        Console.Write(">>>>> ");
        var loginSignup = int.Parse(Console.ReadLine());
        Console.WriteLine("\n");

        while (loginSignup is string || loginSignup > 2)
        {
            Console.WriteLine("Input the correct value...");
            Console.Write(">>>>> ");
            loginSignup = int.Parse(Console.ReadLine());
        }

        switch (loginSignup)
        {
            case 1:
                userLogin = AuthModule.SignIn(userStoragePath);
                break;
            case 2:
                userLogin = SignupModule.Signup(userStoragePath);
                SignupModule.CreateAccount(userLogin, accountStoragePath);
                break;
        }

        AddSymbol.AddBreakLine();
    }

    public static void Account(in string userLogin)
    {
        Console.WriteLine("What action do you want to perform");
        Console.WriteLine("Press 1 to VIEW ACCOUNT SUMMARY");
        Console.WriteLine("Press 2 to VIEW BALANCE");
        Console.WriteLine("Press 3 to DEPOSIT");
        Console.WriteLine("Press 4 to WITHDRAW");

        Console.Write(">>>>> ");
        var action = int.Parse(Console.ReadLine());

        switch (action)
        {
            case 1:
                AccountModule.ViewAccountSummary(in userLogin, accountStoragePath);
                break;
            case 2:
                AccountModule.ViewAccountBalance(in userLogin, accountStoragePath);
                break;
            case 3:
                AccountModule.Deposit(in userLogin, accountStoragePath);
                break;
            case 4:
                AccountModule.Withdraw(in userLogin, accountStoragePath);
                break;
            default:
                Console.WriteLine("Input the correct value");
                break;
        }

        Console.WriteLine("Do you want to perform another transaction");
        Console.WriteLine("............ Press 1 to continue");
        Console.WriteLine("............ Press 2 to quit");
        Console.Write(">>>>> ");
        var anotherAction = int.Parse(Console.ReadLine());

        while (anotherAction > 2)
        {
            Console.WriteLine("Please input the correct value.");
            Console.Write(">>>>> ");
            anotherAction = int.Parse(Console.ReadLine());
        }

        if (anotherAction == 1)
        {
            Account(in userLogin);
        }
        else if(anotherAction == 2)
        {
            Console.WriteLine("Thank you for banking with us...");
            Console.WriteLine("Goodbye.");
        }

        AddSymbol.AddBreakLines(symbol: "*");
    }

    private static void Main()
    {
        Auth(out var userLogin);

        Account(in userLogin);
    }
}