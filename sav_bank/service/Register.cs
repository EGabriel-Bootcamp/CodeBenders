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
    public class RegisterService
    {
        public static BankResponse<bool> RegisterUser(SignUpDtos dto, string fileName) {

            var user = DataBase.GetDataByUserId(dto.UserName, fileName);
            if (user != null)
                return new BankResponse<bool>() { Code = "25", Description = "Username exist Already", Data = false };

            PasswordHelper.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var bankModel = new Bank(userName: dto.UserName,  phoneNumber: dto.PhoneNumber,firstName: dto.FirstName, lastName: dto.LastName, email: dto.Email, age: dto.Age, passwordSalt :passwordSalt, passwordHash: passwordHash) {};

           var added = DataBase.AddData(bankModel, fileName);
            if(!added)
              return new BankResponse<bool>() { Code = "25", Description = "Error creating account please try again", Data = false };


            return new BankResponse<bool>() { Code = "00", Description = "Success", Data = true };



        }
    }
}
