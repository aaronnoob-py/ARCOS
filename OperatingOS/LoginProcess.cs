using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

public class LoginProcess
{
    public bool IsLoggedIn = false;
    private string FatFilePath = @"0:\\Database.txt";
    Dictionary<string, string> userCredentials = new Dictionary<string, string>();

    public void Login()
    {
        Console.WriteLine("Log in to Operating OS!");
        Console.Clear();
        Console.WriteLine("Are you an existing user? (Y/N): ");
        string existingUser = Console.ReadLine().ToLower();

        if (existingUser == "n")
        {
            Console.Clear(); // STRAIGHT TO SIGNUP
            SignUpProcess SignUp = new SignUpProcess();
            SignUp.SignUp();
        }
        else if (existingUser == "y")
        {
            AuthenticateUser();
        }
        else
        {
            Console.WriteLine("Invalid option. Please choose Y or N.");
            Thread.Sleep(100);
            Console.Clear();
        }
    }


    public Dictionary<string, string> LoadUserCredentials()
    {
        Dictionary<string, string> userCredentials = new Dictionary<string, string>();

        try
        {
            // Ensure the file exists
            if (!File.Exists(FatFilePath))
            {
                Console.WriteLine($"File not found at {FatFilePath}");
                return userCredentials;
            }

            // Read all lines from the file
            string[] lines = File.ReadAllLines(FatFilePath);

            foreach (string line in lines)
            {
                // Split the line into username and password
                string[] parts = line.Split(':');
                string username = parts[0].Trim();
                string password = parts[1].Trim();
                userCredentials[username] = password;
            }

            Console.WriteLine("User credentials loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading from FAT file: {ex.Message}");
        }

        return userCredentials;
    }

    public string FindPasswordForUser(string username)
    {
        var credentials = LoadUserCredentials();

        if (credentials.ContainsKey(username))
        {
            return credentials[username]; // Return the password
        }
        else
        {
            Console.WriteLine("User not found.");
            return null;
        }
    }

    public bool AuthenticateUser()
    {
        Console.Clear();
        Console.WriteLine("Enter username: "); // input username
        string username2 = Console.ReadLine();
        Thread.Sleep(100);
        Console.WriteLine("Enter password: ");
        string password2 = ReadPassword();

        string[] lines = File.ReadAllLines(FatFilePath);

        bool isAuthenticated = false; // Flag to check authentication status

        foreach (string line in lines)
        {
            // Split the line into username and password
            string[] parts = line.Split(':');
            if (parts.Length < 2)
            {
                continue; // Skip invalid lines
            }

            string username = parts[0].Trim();
            string password = parts[1].Trim();

            // Check if the entered username and password match
            if (username2 == username && password2 == password)
            {
                Console.WriteLine($"{username} {password}");
                Console.WriteLine($"{username2} {password2}");
                Console.WriteLine($"Welcome, {username}.");
                Thread.Sleep(1000);
                isAuthenticated = true;
                return true; // Exit loop after successful authentication
            }
        }
            Console.WriteLine("Incorrect credentials. Please try again.");
            Thread.Sleep(1000);
            Login(); // Retry login if authentication fails
            return false;
        }

    public string SaveUsername(string username)
    {
        string filePath = "0:\\CurrentUser.txt";
        try
        {
            File.WriteAllText(filePath, username);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving username: {ex.Message}");
        }
        return username;
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
