using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Cosmos.HAL.BlockDevice.Registers;
using System.ComponentModel.Design;
using System.Windows.Input;

namespace OperatingOS
{
    internal class Commands
    {
        public void CommandLine()
        {
            Console.Clear();
            Thread.Sleep(5000);
            Console.WriteLine("ARC Operating System v. 1.0.0");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Type menu to return to Main Menu");
            Console.WriteLine("Type commands to show list of all commands");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            bool exitCommandLine = false;

            while (!exitCommandLine)
            {
                Console.Write("\nEnter Command: ");
                string command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "delete":
                        Console.Clear();
                        Console.WriteLine("Screen cleared.");
                        break;

                    case "reboot":
                        Console.WriteLine("Rebooting the system...");
                        Thread.Sleep(1000);
                        Sys.Power.Reboot();
                        break;

                    case "shutdown":
                        Console.WriteLine("Shutting down the system...");
                        Thread.Sleep(1000);
                        Sys.Power.Shutdown();
                        break;

                    case "logout":
                        Console.WriteLine("Logging out...");
                        Thread.Sleep(1000);
                        LoginProcess login = new();
                        login.Login();
                        break;

                    case "version":
                        Console.WriteLine("ARC OS Version: 1.0.0");
                        break;

                    case "menu":
                        Console.WriteLine("Returning to the Main Menu...");
                        exitCommandLine = true;
                        break;

                    case "commands":
                        Console.WriteLine("\n--- Available Commands ---");
                        Console.WriteLine("delete   - Clear the screen");
                        Console.WriteLine("reboot   - Reboot the system");
                        Console.WriteLine("shutdown - Shut down the system");
                        Console.WriteLine("logout   - Log out of the current account");
                        Console.WriteLine("version  - Display the OS version");
                        Console.WriteLine("menu     - Return to the Main Menu");
                        Console.WriteLine("commands - Display this command list");
                        Console.WriteLine("---------------------------");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid command. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
    }
}
