using System;
using System.IO;
using BankingSoftware.Common;

namespace BankingSoftware.Modules;

// Module to handle authentication
public static class AuthModule
{
    public static string SignIn(string userStoragePath)
    {
        Console.Write("Please enter your username: ");
        var username = Console.ReadLine();

        Console.Write("Please enter your password: ");
        var password = Console.ReadLine();
        var hashedPassword = new Hash().HashValues(password.Split());

        var userLogin = new Hash().HashValues(new[] { username, hashedPassword });
        var hashedUsername = new Hash().HashValues(username.Split());
        var userExist = File.Exists(userStoragePath + hashedUsername + ".txt");

        while (!userExist)
        {
            Console.WriteLine("Incorrect username or password, please try again");
            Console.Write("Please enter your username: ");
            username = Console.ReadLine();

            Console.Write("Please enter your password: ");
            password = Console.ReadLine();
            hashedPassword = new Hash().HashValues(password.Split());

            userLogin = new Hash().HashValues(new[] { username, hashedPassword });
            hashedUsername = new Hash().HashValues(username.Split());
            userExist = File.Exists(userStoragePath + hashedUsername + ".txt");
        }

        Console.WriteLine("Welcome {0}", username);

        return userLogin;
    }
}