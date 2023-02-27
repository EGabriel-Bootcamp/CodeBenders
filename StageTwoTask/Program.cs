class Program
{
    static void Main(string[] args)
    {
        string firstName, lastName, username, confirmUsername, email, phoneNumber, password, confirmPassword = string.Empty;
        int age;
        Console.WriteLine("Enter your first name");
        firstName = Console.ReadLine();
        Console.WriteLine("Enter your last name");
        lastName = Console.ReadLine();
        Console.WriteLine("Enter your username");
        username = Console.ReadLine();
        Console.WriteLine("Enter your email");
        email = Console.ReadLine();
        Console.WriteLine("Enter your phone number");
        phoneNumber = Console.ReadLine();
        Console.WriteLine("Enter your age");
        age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your password");
        password = Console.ReadLine();
       
        using (StreamReader sr = new StreamReader(File.Open("D:\\C#\\EGabriel Bootcamp\\CodeBenders\\StageTwoTask\\login.text", FileMode.Open)))

        {
            confirmUsername = sr.ReadLine();
            confirmPassword = sr.ReadLine();
            sr.Close();
        }
        if (username == confirmUsername && password == confirmPassword)
        {
            Console.WriteLine("Login Successful");
        }
        else
        {
            Console.WriteLine("Login Failed");
        }

    }
}