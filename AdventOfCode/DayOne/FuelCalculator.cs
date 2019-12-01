using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayOne
{
    public class FuelCalculator
    {
        public List<int> Masses { get; }

        private const int DIVISOR = 3;
        private const int SUBTRACTOR = 2;

        public FuelCalculator() { }

        public FuelCalculator(string filePath)
        {
            var file = File.ReadAllLines(filePath);

            Masses = file.Select(line => int.Parse(line)).ToList();
        }

        public int CalcFuelForMass(int inputMass)
        {
            double dividedMass = inputMass / DIVISOR;
            int roundedMass = (int)Math.Round(dividedMass);
            return roundedMass - SUBTRACTOR;
        }
    }
}
