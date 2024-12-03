using System;
using System.Collections.Generic;
using System.Linq;
public class LoginSectionTest2
{
    public bool isLoggedIn = false;
    public bool User = false;
    private Dictionary<string, (string, string)> usernames = new Dictionary<string, (string, string)>();
    string path = @"C:\OperatingOS\UserData\Database.txt";
        
    public void Login()
    {
        int CopiedUsername = 0;
        Console.WriteLine("Are you an existing user? Y/N ");
        string ExistingUser = Console.ReadLine();
        ExistingUser = ExistingUser.ToLower();
        Console.WriteLine(ExistingUser + "Test");

        if (ExistingUser == "n")
        { //make user profile (signup)
            while (CopiedUsername != 1)
            {
                Console.Clear();
                Console.WriteLine("Create an account! \n");
                Console.WriteLine("Enter username: ");
                string user = Console.ReadLine();
                // chceking if user exists already.. 
                if (usernames.ContainsKey(user))
                {// yeah.
                    Console.WriteLine("User already exists. Choose another name.");
                    CopiedUsername = 2;
                }
                else
                {//nope. you're good. added to dictionary.
                    CopiedUsername = 1;
                    usernames.Add(user, (user, "PASSWORD"));
                }
            }
            //password time!
            Console.Clear();
            Console.WriteLine("Enter password: \n");

            string password = "";
            while (true)
            {
                var key = Console.ReadKey(true);  // true to not display the key, read enter
                var key2 = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1); // Remove last character
                        Console.Write("\b \b");
                    }
                }
                /* else if (key2.Key == ConsoleKey.End)
                { while (true) {
                        Console.ReadKey(false){
                        
                        }
                   }
                } */
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");  // Display asterisk for each character
                }
            }

            // After password input, update dictionary with the new password
            string username = usernames.Keys.Last(); // Get the last added user, assuming it's the one just created
            usernames[username] = (username, password); // Update the dictionary with the actual password

            Console.Clear();
            Console.WriteLine("Account created successfully! You can now log in.");
        }
    }

    public void EditUser(string username)
    {
        // Check if the user exists
        if (usernames.ContainsKey(username))
        {
            Console.WriteLine("User found. Enter new details:");

            // Get new password
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            // Update the user's information
            usernames[username] = (username, newPassword); 

            Console.WriteLine("User information updated successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
}
 