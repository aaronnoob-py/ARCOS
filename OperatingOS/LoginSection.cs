using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class LoginSection2
{
    public bool IsLoggedIn = false;
    private string filePath = @"C:\OperatingOS\UserData\Database.txt";

    public void Login()
    {
        Console.Clear();
        Console.WriteLine("Are you an existing user? (Y/N): ");
        string existingUser = Console.ReadLine().ToLower();

        if (existingUser == "n")
        {
            SignUp();
            Console.Clear();
            Login();
        }
        else if (existingUser == "y")
        {
            UserLogin();
        }
        else
        {
            Console.WriteLine("Invalid option. Please choose Y or N.");
        }
    }

    private void SignUp()
    {
        Console.Clear();
        Console.WriteLine("Create an account!");

        string username;
        while (true)
        {
            Console.Write("Enter username: ");
            username = Console.ReadLine();

            if (DoesUserExist(username))
            {
                Console.WriteLine("Username already exists. Please choose another.");
            }
            else
            {
                break;
            }
        }

        Console.Write("Enter password: ");
        string password = ReadPassword();

        SaveUser(username, password);
        Console.WriteLine("\nAccount created successfully! You can now log in.");
    }

    private void UserLogin()
    {
        Console.Clear();
        Console.WriteLine("Login to your account!");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = ReadPassword();

        if (AuthenticateUser(username, password))
        {
            Console.WriteLine("\nLogin successful!");
            IsLoggedIn = true;
        }
        else
        {
            Console.WriteLine("\nInvalid username or password.");
        }
    }

    private bool DoesUserExist(string username)
    {
        if (!File.Exists(filePath)) return false;

        string[] users = File.ReadAllLines(filePath);
        foreach (var user in users)
        {
            string[] credentials = user.Split(',');
            if (credentials[0] == username)
                return true;
        }
        return false;
    }

    private void SaveUser(string username, string password)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{username},{password}");
        }
    }

    private bool AuthenticateUser(string username, string password)
    {
        if (!File.Exists(filePath)) return false;

        string[] users = File.ReadAllLines(filePath);
        foreach (var user in users)
        {
            string[] credentials = user.Split(',');
            if (credentials[0] == username && credentials[1] == password)
                return true;
        }
        return false;
    }

    private string ReadPassword()
    {
        string password = "";
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password.Substring(0);
                    Console.Write("Please re-input your password. \n");
                }
            }
            else
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        }
        return password;
    }
}

