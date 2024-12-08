using OperatingOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



public class LoginProcess
{
    public bool IsLoggedIn = false;
//    private string FatFilePath = @"0:\\Database.txt";
    Dictionary<string, string> userCredentials = new Dictionary<string, string>();

    public void Login()
    {
        Console.Clear();
        Console.WriteLine("Log in to ARC OS!");
        Console.WriteLine("Are you an existing user? (Y/N): ");
        string existingUser = Console.ReadLine().ToLower();

        if (existingUser == "n")
        {
            Console.Clear(); // STRAIGHT TO SIGNUP
            SignUp();
        }
        else if (existingUser == "y")
        {
            AuthenticateUser();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Invalid option. Please choose Y or N.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.Clear();
            Login();
        }
    }

    public void SignUp()
    {
        Console.Clear();
        Console.WriteLine("Sign up for ARC OS!");

        Console.Write("Enter a username: ");
        string username = Console.ReadLine();
        if (userCredentials.ContainsKey(username))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Username already exists. Please try a different username.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            SignUp();
        }

    Console.Write("Enter a password: ");
        string password = ReadPassword();

    // Add the new user to the in-memory database
        userCredentials[username] = password;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Account created successfully! You can now log in.");
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(1000);
        Login(); // Redirect to login after successful sign-up
}

public bool AuthenticateUser()
    {
        Console.Clear();
        Console.WriteLine("Log in to ARC OS!");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = ReadPassword();

        Console.Clear();
        Console.WriteLine("Loading...");
        Thread.Sleep(1000);

        // Check if the username exists and matches the password
        if ((userCredentials.ContainsKey(username) && userCredentials[username] == password) || ((username == "admin") && (password == "123")))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome, {username}!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect credentials. Please try again.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Login(); // Retry login if authentication fails
            return false;
        }
    }

    private string ReadPassword()
    {
        string password = "";
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;
            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Clear();
                Console.Write("Please reenter your username and password.");
                Thread.Sleep(2500);
                Login();

                password = password.Substring(0, password.Length - 1);
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");

                password += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);
        Console.WriteLine();
        return password;
    }
}
