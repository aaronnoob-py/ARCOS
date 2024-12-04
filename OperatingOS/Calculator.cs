using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OperatingOS
{
    internal class Calculator
    {   public void Calcu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Calculator");
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("Enter + for Addition ");
                Console.WriteLine("Enter - for Subtraction ");
                Console.WriteLine("Enter * for Multiplication");
                Console.WriteLine("Enter / for Division ");
                Console.WriteLine("Enter 'menu' to go back to the Main Menu");
                Console.Write("\nEnter your choice: ");

                string operation = Console.ReadLine()?.ToLower();
                if (operation == "menu")
                {
                    return; 
                }

                double num1, num2;
                try

                {
                    Console.Write("\nEnter first number: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter second number: ");
                    num2 = Convert.ToDouble(Console.ReadLine());
                }

                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid input. Please enter numeric values.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadLine();
                    return;
                }

                double result;
                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        Console.WriteLine($"\n{num1} + {num2} = {result}");
                        break;
                    case "-":
                        result = num1 - num2;
                        Console.WriteLine($"\n{num1} - {num2} = {result}");
                        break;
                    case "*":
                        result = num1 * num2;
                        Console.WriteLine($"\n{num1} * {num2} = {result}");
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("\nError: Division by zero is not allowed.");
                        }
                        else
                        {
                            result = num1 / num2;
                            Console.WriteLine($"\n{num1} / {num2} = {result}");
                        }
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please select a valid operation.");
                        break;
                }
                // Press Enter to continue

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();

            }

        }
    }
}

