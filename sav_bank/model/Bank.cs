using sav_bank.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace sav_bank.model
{
    public class Bank : IEquatable<Bank>
    {
        [JsonInclude]
        public  string UserId { get; private set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonInclude]
        public string AccountNumber { get; private set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [JsonInclude]
        public  decimal Balance { get; private set; }
        public List<AccountSummary> AccountSummary { get; set; }    
        public Bank()
        {
           
        }
       
        public Bank(string userName, string email, string phoneNumber, string firstName, string lastName, string age, byte[] passwordHash, byte[] passwordSalt)
        {
            UserId = PasswordHelper.GenerateUserId();
            AccountNumber = PasswordHelper.GenerateAccountNumber();
            UserName = userName;
            Email = email;
            Age = age;
            FirstName = firstName; 
            LastName = lastName;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Balance = 0;
            AccountSummary = new List<AccountSummary>();

        }

        public bool Equals(Bank other)
        {
            if (this.AccountNumber != other.AccountNumber) return false;
            if (this.UserId != other.UserId) return false;


            return true;
        }

        public decimal AddAcountBalance(decimal amount)
        {
            if(amount > 0)
            {
               
                this.Balance += amount;
                AddSummary(amount.ToString(), true);
                return this.Balance;
            }
            else
            {
                return -1;
            }
        }
        public decimal Withdraw(decimal amount)
        {
            if (amount > 0 && this.Balance > 0 && this.Balance > amount)
            {
                this.Balance = this.Balance -  amount;
                AddSummary(amount.ToString(), false);
                return this.Balance;
            }
            else
            {
                return -1;
            }
        }

        private void AddSummary(string amount, bool isDeposit)
        {
            var summary = new AccountSummary()
            {
                Amount = amount,
                Date = DateTime.Now.ToString(),
                IsDeposit= isDeposit,
                CurrentBalance = this.Balance.ToString(),

            };

            AccountSummary.Add(summary);
        }
    }
}
