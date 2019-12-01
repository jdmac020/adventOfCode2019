using System;
using Xunit;
using Shouldly;

namespace DayOne.Tests
{
    public class FuelCalculatorShould
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void ReturnNecssaryFuel(int inputMass, int neededFuel)
        {
            var calculator = new FuelCalculator();

            var calculatedFuel = calculator.CalcFuelForMass(inputMass);

            calculatedFuel.ShouldBe(neededFuel);
        }
    }
}
