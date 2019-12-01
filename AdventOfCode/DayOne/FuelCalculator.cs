using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayOne
{
    public class FuelCalculator
    {
        public List<FuelNeed> FuelNeeds { get; }

        private const int DIVISOR = 3;
        private const int SUBTRACTOR = 2;

        public FuelCalculator() { }

        public FuelCalculator(string filePath)
        {
            var file = File.ReadAllLines(filePath);

            FuelNeeds = file.Select(line => new FuelNeed
            {
                ModuleMass = int.Parse(line)
            })
            .ToList();
        }

        public int CalcFuelForMass(int inputMass)
        {
            double dividedMass = inputMass / DIVISOR;
            int roundedMass = (int)Math.Round(dividedMass);
            return roundedMass - SUBTRACTOR;
        }

        public int CalculateFuelForAllModules()
        {
            return FuelNeeds.Select(mass => CalcFuelForMass(mass.ModuleMass)).Sum();
        }
    }
}
