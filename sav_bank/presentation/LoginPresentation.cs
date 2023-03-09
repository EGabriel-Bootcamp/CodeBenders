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
    public class LoginPresentation
    {
    public static Bank PresentLogin(string fileName)

        {
              int attempt = 3;
            string userName;
            string password;
            Console.WriteLine("To Login Enter your user name and Password");
            while(attempt != 0  )
            {

                Console.Write("Username: ");
                userName = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                var login = LoginService.UserLogin(userName, password, fileName);
                if (login.Code.Equals("00"))
                {

                
                    SymbolWriter.WriteSymbol();
                    Console.WriteLine(login.Data.UserName + " logged in successfully");
                    SymbolWriter.WriteSymbol();
                    
                    return login.Data;
                  
                }
                else
                {
                  
                    attempt--;
                    Console.WriteLine("{0} , You have {1} attempts left",login.Description, attempt);
                }
            } 
              if(attempt == 0 )
               Console.WriteLine("You attempted more than 3 times account locked ");
               Console.ReadKey();

            return null;
        }
    }
}
