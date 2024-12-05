using OperatingOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class SignUpProcess {

    public bool IsLoggedIn = false;
    //private string filePath = @"0:\\Database.txt";
    public void SignUp()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Create an account for ARC OS!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Are you an existing user? (Y/N): ");
        string existingUser = Console.ReadLine().ToLower();

        if (existingUser == "n")
        {
            Console.Clear(); // STRAIGHT TO SIGNUP
            SignUpUser();
        }
        else if (existingUser == "y")
        {
            Console.Clear();
            LoginProcess login = new LoginProcess();
            login.Login();

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Invalid option. Please choose Y or N.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.Clear();
            SignUp();
        }
    }

    public void SignUpUser()
    {
        Console.Clear();
        Console.WriteLine("Create an account!");

        string username;
        while (true)
        {
            Console.Write("Enter username: ");
            username = Console.ReadLine();
            if(username == null || ReadPassword == null)
            {
                Console.WriteLine("Invalid entry. Please choose a different username or password.");
                Thread.Sleep(1000);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                SignUpUser();
            }
/*
            if (File.Exists(filePath) && File.ReadAllLines(filePath).Any(line => line.StartsWith(username + ":"))) // ibig sabihin may kopya na
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Username already exists. Please choose another.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(10000);
                SignUpUser();
            }*/
            //else
            //{
                Console.Write("Enter password: ");
                string password = ReadPassword();
                /*try
                {
                    // Write the username and password to the file
                    using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' to append
                    {
                        writer.WriteLine($"\n{username}:{password}");
                        writer.Close();
                   */ }

                    Console.WriteLine("\nAccount created successfully! You can now log in.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                   // break; // Exit the loop
               // }
              //  catch (Exception ex)
             //   {
              //      Console.WriteLine($"Failed to save data: {ex.Message}");
              //      Console.WriteLine("Press any key to retry...");
              //      Console.ReadKey();
               // }
          //  }
        }
//    }

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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please reenter your username and password.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2500);
                SignUpUser();

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
