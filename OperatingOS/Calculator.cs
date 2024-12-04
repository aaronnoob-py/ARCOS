using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingOS
{
    internal class Calculator
    {

        public void Calc()
        {
            Console.Clear();
            Console.WriteLine("=///////////////////////////=");
            //Console.WriteLine($"Welcome, {username}, to OOS!");
            Console.WriteLine("\n");
            Console.WriteLine("Enter '+' to add.");
            Console.WriteLine("Enter '-' to subtract.");
            Console.WriteLine("Enter '/' to divide.");
            Console.WriteLine("Enter '*' to multiply.");

            string Operation = Console.ReadLine();


            Console.WriteLine("\n");



        }
    }
}
