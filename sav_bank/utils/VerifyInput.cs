using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank.utils
{
    public class VerifyInput
    {
        public static string VerifyEmptyOrNull(string input)
        {
            while (
                string.IsNullOrEmpty(input)
               
            )
            {
                Console.WriteLine("Input must not be empty");
                Console.Write("Please input new value: ");
                input = Console.ReadLine();
            }

          
            return input;
        }
    }
}
