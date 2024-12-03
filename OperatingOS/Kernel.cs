using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;


namespace OperatingOS
{

    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
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
                Console.WriteLine("Enter '1' to sign in!");
                Console.WriteLine("Enter '2' to reboot the system");
                Console.WriteLine("Enter '3' to shut down");
                Console.WriteLine("\n");

                var available_space = fs.GetAvailableFreeSpace(@"0:\");
                Console.WriteLine("Available Free Space: " + available_space);
                var fs_type = fs.GetFileSystemType(@"0:\");
                Console.WriteLine("File System Type: " + fs_type);
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

                        case 3:
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
                    }
                }
            }
        }
        protected override void Run()
        {
            // woke up this morning got some gabagool
            Console.Clear();
            Console.WriteLine("=///////////////////////////=");
            Console.WriteLine($"Welcome, {username}, to OOS!");
            Console.WriteLine("\n");
            Console.WriteLine("Enter '1' to access Clock.");
            Console.WriteLine("Enter '2' to access Calculator.");
            Console.WriteLine("Enter '3' to change user password.");
            Console.WriteLine("Enter '4' to access system information.");
            Console.WriteLine("Enter '5' to reboot the system.");
            Console.WriteLine("Enter '6' to shut down.");
            Console.WriteLine("\n");
            string ChoicePrompt2 = Console.ReadLine();

            if (!int.TryParse(ChoicePrompt2, out int ChoicePrompt2Converted))
            {
                Console.WriteLine("Invalid choice! Press any key to return to menu.");
                Console.ReadKey();

            }
            else
            {
                switch (ChoicePrompt2Converted)
                {
                    case 1:
                        

                        break;

                }

            }
        }
    }
}
