using sav_bank.model;
using sav_bank.service;
using sav_bank.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.presentation
{
    public class AccountPresentation
    {

        private static void WriteSumarry(AccountSummary summary)
        {
            Console.WriteLine("Deposit Date: {0}\n{1} Amount: N{2}\nCurrent balance: N{3}", summary.Date, summary.IsDeposit ? "Deposit" : "Withdrawal", summary.Amount, summary.CurrentBalance);
            SymbolWriter.WriteSymbol(symbol: "$");
        }
        public static void PresentAccount(in Bank user, string fileName) {
            Console.WriteLine("Bank with us:");
            Console.WriteLine("Press 1 to VIEW ACCOUNT SUMMARY");
            Console.WriteLine("Press 2 to VIEW BALANCE");
            Console.WriteLine("Press 3 to DEPOSIT");
            Console.WriteLine("Press 4 to WITHDRAW");

            Console.Write(">>>>> ");
            var action = int.Parse(Console.ReadLine());

            switch (action)
            {
                case 1:
                    var accountSummary = AccountService.GetAccountSummary(user.UserName, fileName);
                    if (accountSummary.Code.Equals("00"))
                    {
                        SymbolWriter.WriteSymbol();

                        foreach (var summary in accountSummary.Data)
                            WriteSumarry(summary);
                        SymbolWriter.WriteSymbol();
                    }
                    else
                    {
                        Console.WriteLine(accountSummary.Description);
                    }
                    break;
                case 2:
                  var accountBalance =  AccountService.GetAccountBalance(user.UserName, fileName);
                    if (accountBalance.Code.Equals("00"))
                    {
                        Console.WriteLine("Account Balance: N{0}", accountBalance.Data);
                    }
                    else
                    {
                        Console.WriteLine(accountBalance.Description);
                    }
                    break;
                case 3:
                    var deposit = AccountService.DepositAccount(user.UserName, fileName);
                    if (deposit.Code.Equals("00"))
                    {
                        Console.WriteLine("Account Balance: N{0}", deposit.Data);
                    }
                    else
                    {
                        Console.WriteLine(deposit.Description);
                    }
                    break;
                case 4:
                    var withdraw = AccountService.Withdraw(user.UserName, fileName);
                    if (withdraw.Code.Equals("00"))
                    {
                        Console.WriteLine("Account Balance: N{0}", withdraw.Data);
                    }
                    else
                    {
                        Console.WriteLine(withdraw.Description);
                    }
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
                PresentAccount(in user, fileName);
            }
            else if (anotherAction == 2)
            {
                Console.WriteLine("Thank you for banking with us");
            
            }

            SymbolWriter.WriteSymbol();
        }
    }
}
