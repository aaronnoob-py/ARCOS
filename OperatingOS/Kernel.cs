using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Cosmos.HAL.BlockDevice.Registers;
using System.Runtime.Remoting;
using Cosmos.System.FileSystem.VFS;
using Cosmos.Core.Memory;
using Cosmos.Core;
using Cosmos.System.Graphics.Fonts;
using System.Reflection.Emit;
using ARCOS;

namespace OperatingOS
{
    public class Kernel : Sys.Kernel
    {
        //var dir = Directory.GetCurrentDirectory;
        //var file = (filename);
        //File.Create(dir + "\\" + file);

        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
        //private string FatFilePath = @"0:\\Database.txt";
        //private string CurrentUserPath = @"0:\\CurrentUser.txt";
        protected override void BeforeRun()
        {
            bool ValidChoice = false;
            
            Console.WriteLine("ARC OS initialized.");
            Thread.Sleep(5000);
            Console.Clear();

            while (ValidChoice == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   █████████   ███████████     █████████        ███████     █████████ ");
                Console.WriteLine("  ███░░░░░███ ░░███░░░░░███   ███░░░░░███     ███░░░░░███  ███░░░░░███");
                Console.WriteLine(" ░███    ░███  ░███    ░███  ███     ░░░     ███     ░░███░███    ░░░ ");
                Console.WriteLine(" ░███████████  ░██████████  ░███            ░███      ░███░░█████████ ");
                Console.WriteLine(" ░███░░░░░███  ░███░░░░░███ ░███            ░███      ░███ ░░░░░░░░███");
                Console.WriteLine(" ░███    ░███  ░███    ░███ ░░███     ███   ░░███     ███  ███    ░███");
                Console.WriteLine(" █████   █████ █████   █████ ░░█████████     ░░░███████░  ░░█████████ ");
                Console.WriteLine("░░░░░   ░░░░░ ░░░░░   ░░░░░   ░░░░░░░░░        ░░░░░░░     ░░░░░░░░░  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nWelcome to ARC OS!\n");

                Console.WriteLine("Enter '1' to Create an Account");
                Console.WriteLine("Enter '2' to Log In");
                Console.WriteLine("Enter '3' to Reboot the System");
                Console.WriteLine("Enter '4' to Shut Down");
                Console.Write("\nChoose an option: ");
                
                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out int ChoicePrompt1Converted))
                {
                    Console.ReadKey();
                }
                switch (ChoicePrompt1Converted)
                {
                    case 1:
                        LoginProcess Login = new();
                        Login.SignUp();
                        ValidChoice = true; // Exit the loop after a valid choice
                        Run();
                        break;

                    case 2:

                        ValidChoice = true;
                        bool isAuthenticated = false;
                        LoginProcess Login2 = new();
                        //Login.Login();

                        if (Login2.AuthenticateUser())
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
                            ValidChoice = false;
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
                            ValidChoice = false;
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
                            Console.Clear();
                            Console.WriteLine("Shutting Down.. ");
                            Thread.Sleep(1000);
                            Sys.Power.Shutdown();
                            //Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Shutdown canceled. Press any key to return to the menu.");
                            ValidChoice = false;
                            Console.ReadKey();
                        }

                        ValidChoice = true;
                        break;
                    case 5:
                        string filePath = ("");
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

                    default:
                        Console.WriteLine("Invalid choice! Press any key to return to menu.");
                        Console.ReadKey();
                        break;

                        /*case 1:
                            LoginProcess Login = new();
                            Login.SignUp();
                            ValidChoice = true; // Exit the loop after a valid choice
                            Run();
                            break;

                        case 2:

                            ValidChoice = true;
                            bool isAuthenticated = false;
                            LoginProcess Login2 = new();
                            //Login.Login();

                            if (Login2.AuthenticateUser())
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
                                ValidChoice = false;
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
                                ValidChoice = false;
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
                                Console.Clear();
                                Console.WriteLine("Shutting Down.. ");
                                Thread.Sleep(1000);
                                Sys.Power.Shutdown();
                                //Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("Shutdown canceled. Press any key to return to the menu.");
                                ValidChoice = false;
                                Console.ReadKey();
                            }

                            ValidChoice = true;
                            break;
                        case 5:
                            string filePath = ("");
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

                        default:
                            Console.WriteLine("Invalid choice! Press any key to return to menu.");
                            Console.ReadKey();
                            break; */
                }
            }
        }


        protected override void Run()
        { 

            string[] commands = {"1","2","3","4","5","6","7","8","9","10","commands"};

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("  __  __ ______ _   _ _    _ ");
            Console.WriteLine(" | \\  / | |__  |  \\| | |  | |");
            Console.WriteLine(" | |\\/| |  __| | . ` | |  | |");
            Console.WriteLine(" | |  | | |____| |\\  | |__| |");
            Console.WriteLine(" |_|  |_|______|_| \\_|\\____/ ");
            

            Console.WriteLine("\n");
            Console.WriteLine("Welcome to ARC OS Main Menu!");
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------APPS----------------");
            Console.WriteLine("Enter '1' to access Clock.");
            Console.WriteLine("Enter '2' to access Calculator.");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------GAMES----------------");
            Console.WriteLine("Enter '3' to access Number Guessing Game");
            Console.WriteLine("Enter '4' to access Rock Paper Scissors");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-----------------UTILITIES----------------");
            Console.WriteLine("Enter '5' to access ARC OS kernel version.");
            Console.WriteLine("Enter '6' to log out.");
            Console.WriteLine("Enter '7' to reboot the system.");
            Console.WriteLine("Enter '8' to shut down.");
            Console.WriteLine("Enter 'commands' to see commands.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            string ChoicePrompt2 = Console.ReadLine();

            if (!Array.Exists(commands, command => command == ChoicePrompt2))
            {
                Console.WriteLine("Invalid choice! Press any key to return to menu.");
                Console.ReadKey();

            }
            /*if (ChoicePrompt2 == "commands")
            {
                Console.WriteLine("Accessing command list.");
                Thread.Sleep(1000);
                Commands CommandLine = new Commands();
                CommandLine.CommandLine();
            }*/

            else
            {
                switch (ChoicePrompt2)
                {
                    case "1":
                        Clock ClockTime = new();
                        ClockTime.ClockTime();
                        break;

                    case "2":
                        Calculator Calc = new(); // calculator
                        Calc.Calcu(); 
                        break;

                    case "3":
                        GuessTheNumber newGame = new(); // numguess
                        newGame.NumberGuess();
                        break;

                    case "4":
                        RockPaperScissors RPSGame = new(); // rps
                        RPSGame.RPSGame();
                        break;

                    case "5":
                        //var totalfreespace = fs.GetTotalFreeSpace(@"0:\");
                        //var available_space = fs.GetAvailableFreeSpace(@"0:\");
                        //var fs_type = fs.GetFileSystemType(@"0:\");

                        Console.Clear();
                        Console.WriteLine("Version of ARC OS: 1.0.0");
                        Console.WriteLine("\n");
                        //Console.Write($"\nTotal Free Space: {totalfreespace}  ");
                        //Console.WriteLine("\nAvailable Free Space: " + available_space);
                        //Console.WriteLine("File System Type: " + fs_type);
                        Console.WriteLine("Press any key to return to the menu.");
                        Console.ReadKey();
                        Run();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to log out? Y/N");
                        string LOConfirmation = Console.ReadLine();
                        string LOConfirmationLower = LOConfirmation.ToLower();
                        if (LOConfirmationLower == "y")
                        {
                            Console.Clear();
                            LoginProcess LoggedOut = new();
                            LoggedOut.Login();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Logout canceled. Press any key to return to the menu.");
                            Console.ReadKey();
                        }
                        break;

                    case "7":                        
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
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Reboot canceled. Press any key to return to the menu.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                        }
                        break;

                    case "8":
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to shut down? Y/N");
                        string Confirmation = Console.ReadLine();
                        string ConfirmationLower = Confirmation.ToLower();

                        if (ConfirmationLower == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Shutting Down.. ");
                            Thread.Sleep(1000);
                            Sys.Power.Shutdown();
                            //Environment.Exit(0);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Shutdown canceled. Press any key to return to the menu.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                        }
                        break;
                    case "commands":
                            Console.WriteLine("Accessing command list.");
                            Thread.Sleep(1000);
                            Commands CommandLine = new Commands();
                            CommandLine.CommandLine();
                        break;
                        }

            }
        }
    }
}

