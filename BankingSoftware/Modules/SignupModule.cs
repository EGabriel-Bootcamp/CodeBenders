using System;
using BankingSoftware.Common;

namespace BankingSoftware.Modules;

// Module to handle signin and creation of account
public class SignupModule
{
    //const string StoragePath = 

    public static string Signup(string userStoragePath)
    {
        string[] userKeys =
        {
            "First Name: ", "Last Name: ", "Email: ", "Username: ", "Age: ", "Phone Number: ",
            "HashedPassword: "
        };
        var userValues = new string[userKeys.Length + 1];

        Console.WriteLine("Please answer the questions below to signup...");
        AddSymbol.AddBreakLine(symbol: " ");

        Console.Write("Enter your first name: ");
        var firstName = Console.ReadLine();
        VerifyInput.VerifyForStringOnly(firstName);
        userValues[0] = userKeys[0] + firstName;
        AddSymbol.AddBreakLine();

        Console.Write("Enter your last name: ");
        var lastName = Console.ReadLine();
        VerifyInput.VerifyForStringOnly(lastName);
        userValues[1] = userKeys[1] + lastName;
        AddSymbol.AddBreakLine();

        Console.Write("Enter your email: ");
        var email = Console.ReadLine();
        email = VerifyInput.VerifyEmail(email);
        userValues[2] = userKeys[2] + email;
        AddSymbol.AddBreakLine();

        Console.Write("Enter your username: ");
        var username = Console.ReadLine();
        username = VerifyInput.VerifyForStringAndNumber(username);
        userValues[3] = userKeys[3] + username;
        AddSymbol.AddBreakLine();

        Console.Write("Enter your age: ");
        var age = int.Parse(Console.ReadLine());
        age = VerifyInput.VerifyNumber(age);
        while (age < 18 || age > 100)
        {
            Console.WriteLine("Age should be between 18 and 100");
            Console.Write("Input new value");
            Console.ReadLine();

            age = int.Parse(Console.ReadLine());
            VerifyInput.VerifyNumber(age);
        }

        userValues[4] = userKeys[4] + age;
        AddSymbol.AddBreakLine();

        Console.Write("Enter your phone number: ");
        var phoneNumber = Console.ReadLine();
        phoneNumber = VerifyInput.VerifyPhoneNumber(phoneNumber);
        userValues[5] = userKeys[5] + phoneNumber;
        AddSymbol.AddBreakLine();

        Console.Write("Enter your password: ");
        var password = Console.ReadLine();
        password = VerifyInput.VerifyPassword(password);
        var hashedPassword = new Hash().HashValues(password.Split());
        userValues[6] = userKeys[6] + hashedPassword;
        AddSymbol.AddBreakLines(lineLength: 2);

        var hashedUsername = new Hash().HashValues(username.Split());
        userStoragePath += "\\" + hashedUsername + ".txt";
        WriteFile.WriteLines(userValues, userStoragePath);

        var credentials = new Hash().HashValues(new[] { username, hashedPassword });

        return credentials;
    }

    public static void CreateAccount(in string userLogin, string accountStoragePath)
    {
        string[] accountValues =
        {
            "Last withdrawal amount: $0", "Last withdrawal time: ", "Last deposit amount: $0",
            "Last deposit time: ", "Total: $0"
        };

        var charFileName = userLogin.Split();
        var hashedFileName = new Hash().HashValues(charFileName);

        var accountFilename = accountStoragePath + hashedFileName + ".txt";
        WriteFile.WriteLines(accountValues, accountFilename);
    }
}