using Cosmos.Core.Memory;
using System;
using System.Runtime.Intrinsics.Arm;
using System.Threading;

public class RockPaperScissors
{
    public void RPSGame()
    {
        Console.Clear();
        Console.WriteLine("Rock Paper Scissors Game!");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Enter 'play' to play the game.");
        Console.ForegroundColor = ConsoleColor.White;
        string back = Console.ReadLine().ToLower();

        switch (back)
        {
            case "play":
                RPSChoices();
                break;
            default:
                Thread.Sleep(2000);
                Console.WriteLine("Invalid choice! .. Returning to Menu");
                Thread.Sleep(2000);
                break;

        }
    }

    public void RPSChoices()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Rock, Paper, Scissors!");
        Console.WriteLine("Enter your choice (rock, paper, scissors):");
                string userChoice = Console.ReadLine().ToLower();

                if ((userChoice == "rock") || (userChoice == "paper") || (userChoice == "scissors")){
                    RPSCore(userChoice);
                }
                else
                {
                    Console.WriteLine("Invalid choice! Press any button to return to menu.");
                    Console.ReadLine();
                    Thread.Sleep(1000);
                    RPSGame();
                    
                }
    }

    public void RPSCore(string userChoice)
    {
        Random random = new Random();
        string[] options = { "rock", "paper", "scissors" };
        string computerChoice = options[random.Next(0, 3)];

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Computer chose: {computerChoice}");

        if (userChoice == computerChoice) { Console.WriteLine("It's a tie!"); }

        else if ((userChoice == "rock" && computerChoice == "scissors") ||
                 (userChoice == "paper" && computerChoice == "rock") ||
                 (userChoice == "scissors" && computerChoice == "paper")) {
            Console.WriteLine("You win!");
            Console.WriteLine("\n Press any key to return to the menu.");
            Console.ReadLine();
            return;
        }
        else
        {
            Console.WriteLine("You lose!"); Console.WriteLine("\n Press any key to return to the menu."); Console.ReadLine();
            return;
        }
    }
}
