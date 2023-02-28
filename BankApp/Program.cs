namespace BankApp
{
	class BankApp
	{
		public static List<User> users = new List<User>();
		static void Main(string[] args)
		{

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
						users.Add(new User(username, password));
						Console.WriteLine("User created successfully!");
						break;
					case "2":
						User? new_user = users.Find(u => u.Username == username && u.Password == password);
						if (new_user == null)
						{
							Console.WriteLine("Incorrect username or password. Please try again.");
						}
						else
						{
							Console.WriteLine($"Welcome, {new_user.Username}!");
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
			// FindFiles("/home/imitor/Documents/git_repos/Practices/CodeBenders/BankApp");
		}

		// public static IEnumerable<string> FindFiles(string folderName)
		// {
		// 	List<string> files = new List<string>();
		// 	var found = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);
		// 	foreach (var file in found)
		// 	{
		// 		files.Add(file);
		// 		System.Console.WriteLine(file);
		// 	}

		// 	return files;
		// }
	}
}