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
    internal class Commands
    {
        public void CommandLine() {
            Console.WriteLine("ARC Operating System v. 1.0.0");
            Console.WriteLine("Type menu to return to Main Menu");
            string Command = Console.ReadLine().ToLower();

            string[] Commands = { "r Delete", "r Reboot", "r Logout", "r Shutdown", "r Initialize, menu" }; // Add custom commands here
            
            switch (Command)
            {
                case "Delete":
                    Console.Clear();
                    break;

                case "r Reboot":
                    Sys.Power.Reboot();
                    break;

                case "r Logout":
                    LoginProcess Login = new();
                    Login.Login();
                    break;

                case "r Shutdown":
                    Sys.Power.Shutdown();
                    break;

                    default:
                        Console.WriteLine("Invalid command."); // add custom commands here
                        break;    
                 }
            }
        }
    }
