using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;

namespace OperatingOS
{
    internal class MainLandingPage
    {
        bool ValidChoice = false;
        public void MainMenu()
        {
            Console.WriteLine("Enter '1' to sign in!");
            Console.WriteLine("Enter '2' to reboot the system");
            Console.WriteLine("Enter '3' to shut down");
            Console.WriteLine("\n");
            string ChoicePrompt1 = Console.ReadLine();

            if (!int.TryParse(ChoicePrompt1, out int ChoicePrompt1Converted))
            {
                Console.WriteLine("Invalid choice!");
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
                            //BeforeRun();
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
}
