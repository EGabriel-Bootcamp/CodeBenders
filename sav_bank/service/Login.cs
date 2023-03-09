using sav_bank.data;
using sav_bank.model;
using sav_bank.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.service
{
    public class LoginService
    {
      
     
        public static BankResponse<Bank> UserLogin(string username, string password, string fileName)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return new BankResponse<Bank>() { Code = "25", Description = "Null Fields", Data = null };


            var user = DataBase.GetDataByUserId(username, fileName);
            if (user == null)
                return new BankResponse<Bank>() { Code = "25", Description = "User does not exist", Data = null };

            if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return new BankResponse<Bank>() { Code = "25", Description = "Incorrect Username  or Password", Data = null };


            return new BankResponse<Bank>() { Code = "00", Description = "Successfull", Data = user };

        }
    }
}
