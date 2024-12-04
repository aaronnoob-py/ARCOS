using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Cosmos.HAL.BlockDevice.Registers;

namespace OperatingOS
{

    public class Kernel : Sys.Kernel
    {
        //var dir = Directory.GetCurrentDirectory;
        //var file = (filename);
        //File.Create(dir + "\\" + file);

        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
        private string FatFilePath = @"0:\\Database.txt";
        private string CurrentUserPath = @"0:\\CurrentUser.txt";
        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            bool ValidChoice = false;

            while (ValidChoice == false)
            {

                Console.Clear();
                Console.WriteLine("=///////////////////////////=");
                Console.WriteLine("Welcome to OOS!");
                Console.WriteLine("\n");
                Console.WriteLine("Enter '1' to sign up");
                Console.WriteLine("Enter '2' to log in");
                Console.WriteLine("Enter '3' to reboot the system");
                Console.WriteLine("Enter '4' to shut down");
                Console.WriteLine("\n");

                string ChoicePrompt1 = Console.ReadLine();

                if (!int.TryParse(ChoicePrompt1, out int ChoicePrompt1Converted))
                {
                    Console.WriteLine("Invalid choice! Press any key to return to menu.");
                    Console.ReadKey();

                }
                else
                {
                    switch (ChoicePrompt1Converted)
                    {
                        case 1:
                            SignUpProcess SignUp = new SignUpProcess();
                            SignUp.SignUp();
                            ValidChoice = true; // Exit the loop after a valid choice
                            Run();
                            break;

                        case 2:

                            ValidChoice = true;
                            bool isAuthenticated = false;
                            LoginProcess Login = new LoginProcess();
                            //Login.Login();

                            if (Login.AuthenticateUser())
                            {
                                Console.Clear();
                                Console.WriteLine("Login successful! Initializing system...");
                                Thread.Sleep(1000);
                                Run();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Login failed. Returning to the main menu...");
                                Thread.Sleep(1000);
                                BeforeRun();
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Are you sure you want to reboot? Y/N");
                            string RConfirmation = Console.ReadLine();
                            string RConfirmationLower = RConfirmation.ToLower();

                            if (RConfirmationLower == "y")
                            {
                                Console.Clear();
                                Console.WriteLine("Rebooting... ");
                                Thread.Sleep(1000);
                                Sys.Power.Reboot();
                                BeforeRun();
                                //Environment.Exit(0);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Reboot canceled. Press any key to return to the menu.");
                                Console.ReadKey();
                            }

                            ValidChoice = true;
                            break;

                        case 4:
                            Console.WriteLine("Are you sure you want to shut down? Y/N");
                            string Confirmation = Console.ReadLine();
                            string ConfirmationLower = Confirmation.ToLower();

                            if (ConfirmationLower == "y")
                            {
                                Console.WriteLine("Shutting Down.. ");
                                Thread.Sleep(1000);
                                Sys.Power.Shutdown();
                                //Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("Shutdown canceled. Press any key to return to the menu.");
                                Console.ReadKey();
                            }

                            ValidChoice = true;
                            break;
                        case 5:
                            string filePath = @"0:\\Database.txt";
                            if (File.Exists(filePath))
                            {
                                // Delete the file
                                File.Delete(filePath);
                                Console.WriteLine($"File {filePath} has been deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"File {filePath} does not exist.");
                            }
                            break;
                    }
                }
            }
        }



        protected override void Run()
        {
            //Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            //string CurrentUser = "0:\\CurrentUser.txt";
            //string username = File.ReadAllText(CurrentUser);
            string[] commands = {"1","2","3","4","5","6","7","8","9","10","help"};

            Console.Clear();
            Console.WriteLine("=///////////////////////////=");
            //Console.WriteLine($"Welcome, {username}, to OOS!");
            Console.WriteLine("\n");
            Console.WriteLine("Enter '1' to access Clock.");
            Console.WriteLine("Enter '2' to access Calculator.");
            Console.WriteLine("Enter '3' to access system information.");
            Console.WriteLine("Enter '4' to log out.");
            Console.WriteLine("Enter '5' to reboot the system.");
            Console.WriteLine("Enter '6' to shut down.");
            Console.WriteLine("\n");
            string ChoicePrompt2 = Console.ReadLine();

            if (!Array.Exists(commands, command => command == ChoicePrompt2))
            {
                Console.WriteLine("Invalid choice! Press any key to return to menu.");
                Console.ReadKey();

            }
            else
            {
                switch (ChoicePrompt2)
                {
                    case "1":
                        //clock
                        break;
                    case "2":
                        //calculator
                        break;
                    case "3":
                        var totalfreespace = fs.GetTotalFreeSpace(@"0:\");
                        var available_space = fs.GetAvailableFreeSpace(@"0:\");
                        var fs_type = fs.GetFileSystemType(@"0:\");

                        Console.Clear();
                        Console.WriteLine("Version of Operating OS: 1.0.0");
                        Console.Write("\nTotal Free Space: " + totalfreespace);
                        Console.WriteLine("\nAvailable Free Space: " + available_space);
                        Console.WriteLine("File System Type: " + fs_type);
                        Console.WriteLine("Press any key to return to the menu.");
                        Console.ReadKey();
                        Run();
                        break;
                    case "4":
                        break;
                    case "5":                        
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to reboot? Y/N");
                        string RConfirmation = Console.ReadLine();
                        string RConfirmationLower = RConfirmation.ToLower();

                        if (RConfirmationLower == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Rebooting... ");
                            Thread.Sleep(1000);
                            Sys.Power.Reboot();
                            BeforeRun();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Reboot canceled. Press any key to return to the menu.");
                            Console.ReadKey();
                        }
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to shut down? Y/N");
                        string Confirmation = Console.ReadLine();
                        string ConfirmationLower = Confirmation.ToLower();

                        if (ConfirmationLower == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Shutting Down.. ");
                            Thread.Sleep(10000);
                            Sys.Power.Shutdown();
                            //Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Shutdown canceled. Press any key to return to the menu.");
                            Console.ReadKey();
                        }
                        break;

                    case "help":
                        Console.WriteLine("");

                        break;


                }

            }
        }
    }
}

