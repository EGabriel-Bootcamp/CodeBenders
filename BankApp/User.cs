using System;

namespace BankApp
{
	public class User
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public int balance = 0;
		public string filepath = "account.csv";

		public User(string username, string password)
		{
			// if (username is null)
			// {
			// 	System.Console.WriteLine("Username cannot be null"); ;
			// }
			this.Username = username;
			this.Password = password;
		}
		// public void Save()
		// {
		// 	string fileName = "./" + this.Username + ".txt";
		// 	// UserAccounts/
		// 	File.WriteAllText(fileName, this.Password);
		// }
		public void Save()
		// string Username, string Password, int Balance
		{
			try
			{
				using (StreamWriter file = new StreamWriter(this.filepath, true))
				{
					file.WriteLine(this.Username + "," + this.Password + "," + this.balance);
				}
			}
			catch (System.Exception)
			{
				System.Console.WriteLine("Error detected!!!");
				throw;
			}

		}
		public string[]? Login()
		{
			try
			{
				string[] users = File.ReadAllLines(this.filepath);
				for (int i = 0; i < users.Length; i++)
				{
					string[] user = users[i].Split(',');
					if (user[0] == this.Username && user[1] == this.Password)
					{
						System.Console.WriteLine("Welcome back {0}", this.Username);
						return user;
					}
				}
				return null;
			}
			catch (Exception)
			{
				System.Console.WriteLine("Incorrect username/password");
				// System.Console.WriteLine("User does not exist!!!");
				return null;
			}
		}
		public void Deposit(int amount)
		{
			System.Console.WriteLine("#{0} has been deposited into your account", amount);
			this.balance += amount;
			this.Save();
			System.Console.WriteLine("Your new account balance is {0}", this.balance);
		}
		public void Withdraw(int amount)
		{
			System.Console.WriteLine("#{0} has been withdrawn from your account", amount);
			this.balance -= amount;
			this.Save();
			System.Console.WriteLine("Your new account balance is {0}", this.balance);
		}
		// public void Login()
		// {
		// 	string fileName = "./" + this.Username + ".txt";
		// 	string password;
		// 	try
		// 	{
		// 		password = File.ReadAllText(fileName);
		// 	}
		// 	catch (FileNotFoundException)
		// 	{
		// 		System.Console.WriteLine("User does not exist!!!");
		// 		return;
		// 	}
		// 	if (password == this.Password)
		// 	{
		// 		System.Console.WriteLine("Welcome {0}", this.Username.ToUpperInvariant());
		// 	}
		// 	else
		// 	{
		// 		Console.WriteLine("Incorrect password.\nPlease try again.");
		// 	}
		// }
	}
}
