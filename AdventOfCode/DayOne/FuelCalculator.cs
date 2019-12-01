using System;

namespace DayOne
{
    public class FuelCalculator
    {
        private const double DIVISOR = 3;
        private const int SUBTRACTOR = 2;

        public int CalcFuelForMass(int inputMass)
        {
            double dividedMass = inputMass / DIVISOR;
            var roundedMass = Math.Round(dividedMass);
            return (int)roundedMass - SUBTRACTOR;
        }
    }
}
