using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ARCOS
{
    internal class GuessTheNumber
    {
        public void NumberGuess()
        {
            Console.Clear();
            Console.WriteLine("Number Guessing Game!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter 'menu' to go back to Main Menu.");
            Console.WriteLine("Enter 'play' to play the game.");
            Console.ForegroundColor = ConsoleColor.White;
            string back = Console.ReadLine().ToLower();

            switch (back)
            {
                case "menu":
                    Console.WriteLine("Returning to menu...");
                    Thread.Sleep(1000);
                    return;
                case "play":
                    TheGame();
                    break;
            }
        }


        public void TheGame()
            {
                Console.Clear();
            Console.WriteLine("Enter the maximum number you want to guess.");
            Console.ForegroundColor = ConsoleColor.Yellow;            
            Console.WriteLine("Number must be higher than 0!");
            string Num1 = Console.ReadLine();

            if (Int32.TryParse(Num1, out int Num2))
            {
                Console.WriteLine("Are you sure? (Y/N)");
                string Confirmation = Console.ReadLine().ToLower();

                if (Confirmation == "y" || Confirmation == "yes")
                {
                Random random = new Random();
                int number = random.Next(1, Num2);
                int guess;
                
                Console.WriteLine($"Guess a number between 0 and {Num2}");

            do
            {
                Console.Write("Your Guess: ");
                guess = int.Parse(Console.ReadLine());

                if (guess > number)
                    Console.WriteLine("Too high!");
                else if (guess < number)
                    Console.WriteLine("Too low!");
                else
                    Console.WriteLine("Congratulations! You guessed the number.");
                        Thread.Sleep(1000);
            } while (guess != number);
                } 
                if (Confirmation == "n" || Confirmation == "no")
                {
                    NumberGuess();
                }
            }
            else { Console.WriteLine("Invalid input!");
            
            }
        }
    }
}
