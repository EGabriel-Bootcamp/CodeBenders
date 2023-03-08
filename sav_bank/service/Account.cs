using sav_bank.data;
using sav_bank.model;
using sav_bank.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.service
{
    public class AccountService
    {
       
        public  static BankResponse<decimal> GetAccountBalance(String userName, string fileName)
        {
            var user = DataBase.GetDataByUserId(userName, fileName);
            if (user == null)
                return new BankResponse<decimal>() { Code = "25", Description = "User does not exist", Data = 0 };

            Console.WriteLine(user.Balance);

            return new BankResponse<decimal>() { Code = "00", Description = "Success", Data = user.Balance };

        }

        public static BankResponse<List<AccountSummary>> GetAccountSummary(String userName, string fileName)
        {
            var user = DataBase.GetDataByUserId(userName, fileName);
            if (user == null)
                return new BankResponse<List<AccountSummary>> { Code = "25", Description = "User does not exist", Data = null };

             if(user.AccountSummary == null || (user.AccountSummary != null && !user.AccountSummary.Any()))
                return new BankResponse<List<AccountSummary>> { Code = "25", Description = "no records found", Data = null };

            return new BankResponse<List<AccountSummary>> { Code = "00", Description = "Success", Data = user.AccountSummary };

        }
        public static BankResponse<decimal> DepositAccount(String userName, string fileName)
        {
            Console.Write("Enter amount:");
            string input = Console.ReadLine();
          
            VerifyInput.VerifyEmptyOrNull(input);
            int amount = int.Parse(input);
            var user = DataBase.GetDataByUserId(userName, fileName);
            if (user == null)
                return new BankResponse<decimal>() { Code = "25", Description = "User does not exist", Data = 0 };

            var updated = user.AddAcountBalance(amount);
            if (updated == -1)
                return new BankResponse<decimal>() { Code = "25", Description = "Invalid amount", Data = 0 };

            DataBase.Update(user, fileName);
            return new BankResponse<decimal>() { Code = "00", Description = "Success", Data = user.Balance };

        }
        public static BankResponse<decimal> Withdraw(String userName, string fileName)
        {

            Console.Write("Enter amount:");
            string input = Console.ReadLine();

            VerifyInput.VerifyEmptyOrNull(input);
            int amount = int.Parse(input);

            var user = DataBase.GetDataByUserId(userName, fileName);
            if (user == null)
                return new BankResponse<decimal>() { Code = "25", Description = "User does not exist", Data = 0 };

          var updated =   user.Withdraw(amount);
            if(updated == -1)
                return new BankResponse<decimal>() { Code = "25", Description = "Low balance", Data = 0 };


            DataBase.Update(user, fileName);
            return new BankResponse<decimal>() { Code = "00", Description = "Success", Data = user.Balance };

        }
    }
}
