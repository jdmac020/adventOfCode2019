using DayOne;
using System;

namespace DayOneApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thank you for not trying to do this math by hand!\n\n");
            Console.Write("What file contains the module masses? ");
            var file = Console.ReadLine();
            Console.WriteLine("Standby...\n\n\n");

            var calculator = new FuelCalculator(file);

            var fuelNeeded = calculator.CalculateFuelForAllModules();

            Console.WriteLine($"The amount of fuel required is: {fuelNeeded}");
            Console.ReadLine();
        }
    }
}
