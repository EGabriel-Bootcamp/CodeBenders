using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankingSoftware.Common;

public static partial class VerifyInput
{
    public static string VerifyForStringOnly(string input)
    {
        while (
            string.IsNullOrEmpty(input)
            || string.IsNullOrWhiteSpace(input)
            || input.Any(char.IsNumber)
            || input.Any(c =>
            {
                char.IsNumber(c);
                char.IsSymbol(c);
                char.IsPunctuation(c);
                char.IsSeparator(c);
                
                return false;
            })
            )
        {
            Console.WriteLine("Input must not contain any number or symbol");
            Console.Write("Please input new value: ");
            input = Console.ReadLine();
        }
        
        Console.WriteLine("Input is valid");
        return input;
    }

    public static string VerifyForStringAndNumber(string stringNumber)
    {
        while (
            string.IsNullOrEmpty(stringNumber)
            || string.IsNullOrWhiteSpace(stringNumber)
            || stringNumber.Any(c =>
            {
                char.IsLetter(c);
                char.IsPunctuation(c);
                char.IsSymbol(c);
                
                return false;
            })
        )
        {
            Console.WriteLine("Input must not contain any number or symbol");
            Console.Write("Please input new value: ");
            stringNumber = Console.ReadLine();
        }
        
        Console.WriteLine("Input is valid");
        return stringNumber;
    }

    public static int VerifyNumber(int number)
    {
        while (
            string.IsNullOrEmpty(number.ToString())
            || string.IsNullOrWhiteSpace(number.ToString())
            || number.ToString().Any(c =>
            {
                char.IsSymbol(c);
                char.IsPunctuation(c);
                char.IsLetter(c);


                return false;
            })
        )
        {
            Console.WriteLine("Input must not contain any letter or symbol");
            Console.Write("Please input your value: ");
            number = int.Parse(Console.ReadLine());
        }
        
        Console.WriteLine("Number is valid");
        return number;
    }

    public static string VerifyPassword(string password)
    {
        while (
            string.IsNullOrEmpty(password)
            || string.IsNullOrWhiteSpace(password)
            )
        {
            Console.WriteLine("Input must not contain any space");
            Console.Write("Please input new value: ");
            password = Console.ReadLine();
        }
        
        Console.WriteLine("Password is valid");
        return password;
    }

    [GeneratedRegex("^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
    private static partial Regex MyRegex();

    public static string VerifyPhoneNumber(string phoneNumber)
    {
        while (!MyRegex().IsMatch(phoneNumber))
        {
            Console.WriteLine("Input must not contain any letter or symbol");
            Console.Write("Please input new value: ");
            phoneNumber = Console.ReadLine();
        }
        
        Console.WriteLine("Phone number is valid");
        return phoneNumber;
    }

    public static string VerifyEmail(string email)
    {
        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
        
        while (!Regex.IsMatch(email, regex, RegexOptions.IgnoreCase))
        {
            Console.Write("Input a valid email: ");
            email = Console.ReadLine();
        }
        
        Console.WriteLine("Email is valid.");
        return email;
    }
}