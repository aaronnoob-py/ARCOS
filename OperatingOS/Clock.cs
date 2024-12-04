using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingOS
{
    internal class Clock
    {
        public void ClockTime()
        {
            Console.Clear();
            Console.WriteLine("The current time is: ");
            DateTime now = DateTime.Now;
            Console.WriteLine(now);

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            Console.WriteLine("Press any button to return to the menu.");
            Console.ReadLine();
            return;

        }
    }
}
