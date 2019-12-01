using System;
using Xunit;
using Shouldly;

namespace DayOne.Tests
{
    public class FuelCalculatorShould
    {
        [Theory]
        [InlineData(12,2)]
        public void ReturnNecssaryFuel(int inputMass, int neededFuel)
        {
            var calculator = new FuelCalculator();

            var calculatedFuel = calculator.CalcFuelForMass(inputMass);

            calculatedFuel.ShouldBe(neededFuel);
        }
    }
}
