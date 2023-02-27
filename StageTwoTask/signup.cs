namespace BankApp
{
    class Signup
    {
        static void Main(string[] args)
        {
            string firstName, lastName, username, email, phoneNumber, password = string.Empty;
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
            // Console.WriteLine("Your details are as follows:");
            // Console.WriteLine("First Name: " + firstName);
            // Console.WriteLine("Last Name: " + lastName);
            // Console.WriteLine("Username: " + username);
            // Console.WriteLine("Email: " + email);
            // Console.WriteLine("Phone Number: " + phoneNumber);
            // Console.WriteLine("Age: " + age);
            // Console.WriteLine("Password: " + password);
            using (StreamWriter sw = new StreamWriter(File.Create("D:\\C#\\EGabriel Bootcamp\\CodeBenders\\StageTwoTask\\login.text")))
            // D:\C#\EGabriel Bootcamp\CodeBenders\StageTwoTask
            {
                sw.WriteLine(username);
                sw.WriteLine(password);

                sw.Close();
            } 
            Console.WriteLine("Registration Successful");
            Console.ReadLine();
        }
    }
}
