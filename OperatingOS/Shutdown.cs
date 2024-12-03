using System;
using System.Threading;

public class Shutdown
{
	public Shutdown()
	{
		Console.WriteLine("Are you sure you want to shut down? Y/N");
		string Confirmation = Console.ReadLine();
		string ConfirmationLower = Confirmation.ToLower();

		if (ConfirmationLower == "n")
		{
			Console.WriteLine("Shutting Down.. ");
			Thread.Sleep(1000);
			Environment.Exit(0);
		}
	}
}
