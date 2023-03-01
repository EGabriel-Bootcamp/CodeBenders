namespace BankApp
{
	class BankApp
	{
		public static List<User> users = new List<User>();
		static void Main(string[] args)
		{

			System.Console.WriteLine(users);
			Start();
		}
		static void Start()
		{
			Console.WriteLine("Welcome to Code Benders Microfinance Bank!");
			Console.WriteLine("Press\n1 to sign up,\n2 to sign in\n3 to exit:");
			string? choice = Console.ReadLine();

			while (choice != "3")
			{
				Console.Write("Enter a username: ");
				string? username = Console.ReadLine();
				Console.Write("Enter a password: ");
				string? password = Console.ReadLine();

				switch (choice)
				{
					case "1":
						User new_user = new User(username, password);
						users.Add(new_user);
						new_user.Save();
						Console.WriteLine("User created successfully!");
						break;
					case "2":
						User return_user = new User(username, password);
						string[]? userBack = return_user.Login();
						System.Console.WriteLine("Your account balance is # {0}", userBack.GetValue(2));

						System.Console.WriteLine("For Deposit press (1)\nfor Withdrawal press (2)\npress (3) to exit");
						string? login_choice = Console.ReadLine();
						switch (login_choice)
						{
							case "1":
								System.Console.WriteLine("How much would you like to Deposit?");
								int amount;
								int.TryParse(Console.ReadLine(), out amount);
								return_user.Deposit(amount);
								break;
							case "2":
								System.Console.WriteLine("How much would you like to Withdraw?");
								int.TryParse(Console.ReadLine(), out amount);
								return_user.Withdraw(amount);
								break;
							default:
								break;
						}
						break;
					case "3":
						break;
					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
				System.Console.WriteLine("What would you like to do next ?");
				Console.WriteLine("Press\n1 to sign up,\n2 to sign in\n3 to exit:");
				choice = Console.ReadLine();
			}

		}
	}
}