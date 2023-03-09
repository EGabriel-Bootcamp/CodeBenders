using sav_bank.service;
using sav_bank.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.presentation
{
    public class RegistrationPresentation
    {
        public static bool PresentRegister(string fileName) {
            Console.WriteLine("Fill in the following details to register");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            VerifyInput.VerifyEmptyOrNull(firstName);
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            VerifyInput.VerifyEmptyOrNull(lastName);
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            VerifyInput.VerifyEmptyOrNull(userName);
            Console.Write("Email: ");
            string email = Console.ReadLine();
            VerifyInput.VerifyEmptyOrNull(email);
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();
            VerifyInput.VerifyEmptyOrNull(phoneNumber);
            Console.Write("Age: ");
            string age = Console.ReadLine();
            VerifyInput.VerifyEmptyOrNull(age);
            Console.Write("Password: ");
            string password = Console.ReadLine();
            VerifyInput.VerifyEmptyOrNull(password);

            var dto = new SignUpDtos()
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Email = email,
                PhoneNumber = phoneNumber,
                Age = age,
                Password = password,

            };

            var signUp = RegisterService.RegisterUser(dto, fileName);
            if (signUp.Code.Equals("00"))
            {

               
                SymbolWriter.WriteSymbol();
                Console.WriteLine("Account created successfully Procceed to login");
                SymbolWriter.WriteSymbol();
               
            }
            else
            {
               
                Console.WriteLine(signUp.Description);
                Console.WriteLine("Try again")
                    ;
                PresentRegister(fileName);
            }
            return signUp.Data;
        }   
    }
}
