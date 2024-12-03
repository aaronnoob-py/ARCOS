using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class LoginProcess
{
    public bool IsLoggedIn = false;
    private string filePath = @"C:\OperatingOS\UserData\Database.txt";
    private string CheckLoggedIn = "@:\\CurrentUser.txt";
    private string FatFilePath = "0:\\Database.txt";
    
    Dictionary<string, string> userCredentials = new Dictionary<string, string>();
    public void Login()
    {

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
    private void SaveUsername(string username)
    {
        string filePath = @"0:\username.txt";
        try
        {
            File.WriteAllText(filePath, username);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving username: {ex.Message}");
        }
    }
