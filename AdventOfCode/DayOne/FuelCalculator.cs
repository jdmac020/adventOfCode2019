using System;

namespace DayOne
{
    public class FuelCalculator
    {
        public int CalcFuelForMass(int inputMass)
        {
            double dividedMass = inputMass / 3;
            int roundedMass = (int)Math.Round(dividedMass);
            return roundedMass - 2;
        }
    }
}
