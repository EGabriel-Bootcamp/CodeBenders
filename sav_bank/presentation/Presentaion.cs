using sav_bank.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.presentation
{
    public  class Presentaion
    {
       public static void Present(string fileName)
        {
            string input;
           
            while (true) {
                Console.WriteLine("To Login enter 1 to Register enter 2 :");
                input = Console.ReadLine();
                if(input.Equals("1") || input.Equals("2") ){
                    break;
                }
                else
                {
                    Console.WriteLine("You Entered an invalid value " + input);
                }
               
            }

            Bank user = null;
            bool registered = false;

            switch(input)
            {
                case "1":
                  user =  LoginPresentation.PresentLogin(fileName);
                    break; 
                case "2":
                 registered =  RegistrationPresentation.PresentRegister(fileName);
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }

            if(input == "1" && user != null)
            {
                AccountPresentation.PresentAccount(user, fileName);
                Console.ReadKey();
            }
            else if(input == "2" && registered) { Present(fileName); }
           

           
        }
    }
}
