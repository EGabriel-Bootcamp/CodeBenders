using sav_bank.presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sav_bank
{
    internal class Program
    {

        private const string storageFile = "bank.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Sav Bank");
            Presentaion.Present(storageFile);
        }
    }
}
