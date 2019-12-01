using System;

namespace DayOne
{
    public class FuelCalculator
    {
        private const int DIVISOR = 3;
        private const int SUBTRACTOR = 2;

        public int CalcFuelForMass(int inputMass)
        {
            double dividedMass = inputMass / DIVISOR;
            int roundedMass = (int)Math.Round(dividedMass);
            return roundedMass - SUBTRACTOR;
        }
    }
}
