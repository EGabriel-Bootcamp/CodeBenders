using System;

namespace BankApp
{
	public class User
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public User(string username, string password)
		{
			this.Username = username;
			this.Password = password;
		}
		public void Save()
		{
			string fileName = "./" + this.Username + ".txt";
			// UserAccounts/
			File.WriteAllText(fileName, this.Password);
		}
		public void Login()
		{
			string fileName = "./" + this.Username + ".txt";
			string password;
			try
			{
				password = File.ReadAllText(fileName);
			}
			catch (FileNotFoundException)
			{
				System.Console.WriteLine("User does not exist!!!");
				return;
			}
			if (password == this.Password)
			{
				System.Console.WriteLine("Welcome {0}", this.Username.ToUpperInvariant());
			}
			else
			{
				Console.WriteLine("Incorrect password.\nPlease try again.");
			}
		}
	}
}
