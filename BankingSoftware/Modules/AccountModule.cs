using System;
using System.IO;
using BankingSoftware.Common;

namespace BankingSoftware.Modules;

public class AccountModule
{
    private static string GetAccountFile(in string userLogin, string accountStoragePath)
    {
        var charFileName = userLogin.Split();
        var accountFileName = new Hash().HashValues(charFileName) ;
        var accountFilenameWithPath = accountStoragePath + accountFileName + ".txt";

        return accountFilenameWithPath;
    }
    
    private static string[] GetAccountSummary(string accountFilename)
    {
        var accountInfo = File.ReadAllLines(accountFilename);

        return accountInfo;
    }
    
    public static void Deposit(in string userLogin, string accountStoragePath)
    {
        var accountFilename = GetAccountFile(userLogin, accountStoragePath);

        var accountInfo = GetAccountSummary(accountFilename);
        foreach (var info in accountInfo)
        {
            Console.WriteLine(info);
        }
        
        Console.Write("Please enter the amount you want to deposit: ");
        var depositAmount = int.Parse(Console.ReadLine());
        
        while (depositAmount is string && depositAmount < 0 )
        {
            depositAmount = int.Parse(Console.ReadLine());
        }

        var depositAmountLine = accountInfo[2].Split(": $");
        var depositTimeLine = accountInfo[3].Split(": ");
        depositAmountLine[1] = depositAmount.ToString();
        depositTimeLine[1] = DateTime.Now.ToString();
        
        accountInfo[2] = string.Join(": ", depositAmountLine);
        accountInfo[3] = string.Join(": ", depositTimeLine);
        
        var totalLine = accountInfo[4].Split(": $");
        
        var totalAmount = int.Parse(totalLine[1]) + depositAmount;
        totalLine[1] = totalAmount.ToString();
        accountInfo[4] = string.Join(": $", totalLine);
        
        Console.WriteLine("You've deposited ${0} to your account", depositAmount);

        Console.WriteLine("\nYour total amount is ${0}", totalAmount);

        WriteFile.WriteLines(accountInfo, accountFilename);
    }

    public static void Withdraw(in string userLogin, string accountStoragePath)
    {
        var accountFilename = GetAccountFile(userLogin, accountStoragePath);

        var accountInfo = GetAccountSummary(accountFilename);
        var totalLine = accountInfo[4].Split(": $");
        
        Console.Write("Please enter the amount you want to withdraw: ");
        var withdrawAmount = int.Parse(Console.ReadLine());
        var currentTotal = int.Parse(totalLine[1]);
        var finalTotalAmount = currentTotal - withdrawAmount; 

        while (withdrawAmount is string && withdrawAmount < 0)
        {
            Console.WriteLine("Your withdraw amount should be greater than Zero");
            withdrawAmount = int.Parse(Console.ReadLine());
            finalTotalAmount = currentTotal - withdrawAmount;
        }

        if (finalTotalAmount < 0)
        {
            Console.WriteLine("Insufficient balance.");
        }
        else
        {
            var withdrawAmountLine = accountInfo[0].Split(": ");
            var withdrawTimeLine = accountInfo[1].Split(": ");
            withdrawAmountLine[1] = withdrawAmount.ToString();
            withdrawTimeLine[1] = DateTime.Now.ToString();
        
            accountInfo[0] = string.Join(": ", withdrawAmountLine);
            accountInfo[1] = string.Join(": ", withdrawTimeLine);
        
            totalLine[1] = finalTotalAmount.ToString();
            accountInfo[4] = string.Join(": $", totalLine);
        
            Console.WriteLine("You've withdrawn ${0} from your account", withdrawAmount);

            Console.WriteLine("\nYour have ${0} left in your account", finalTotalAmount);
        
            WriteFile.WriteLines(accountInfo, accountFilename);
        }
        
    }

    public static void ViewAccountBalance(in string userLogin, string accountStoragePath)
    {
        var accountFilename = GetAccountFile(userLogin, accountStoragePath);

        var accountBalance = GetAccountSummary(accountFilename)[4];
        
        Console.WriteLine("Your account balance is {0}", accountBalance);
    }

    public static void ViewAccountSummary(in string userLogin, string accountStoragePath)
    {
        var accountFilename = GetAccountFile(userLogin, accountStoragePath);

        var accountInfo = GetAccountSummary(accountFilename);
        
        foreach (var info in accountInfo)
        {
            Console.WriteLine(info);
        }
    }
}