using System;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace DayOne.Tests
{
    public class FuelCalculatorShould
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void ReturnNecessaryFuel(int inputMass, int neededFuel)
        {
            var calculator = new FuelCalculator();

            var calculatedFuel = calculator.CalcFuelForMass(inputMass);

            calculatedFuel.ShouldBe(neededFuel);
        }

        [Fact]
        public void CreateListOfFuelNeedsWhenGivenFileName()
        {
            var calculator = new FuelCalculator("testData.txt");

            calculator.FuelNeeds.ShouldBeOfType<List<FuelNeed>>();
            calculator.FuelNeeds.First().ModuleMass.ShouldBe(12);
            calculator.FuelNeeds.First().ForModule.ShouldBe(2);
            calculator.FuelNeeds.First().ForFuel.ShouldBe(0);
        }

        [Fact]
        public void ReturnFuelForAllMassesInList()
        {
            var calculator = new FuelCalculator("testData.txt");

            var totalFuel = calculator.CalculateFuelForAllModules();

            totalFuel.ShouldBe(34241);
        }

        [Fact]
        public void ReturnFuelNeededForFuel()
        {
            var calculator = new FuelCalculator();

            var fuelForFuel = calculator.CalcFuelForFuel(2);

            fuelForFuel.ShouldBe(0);
        }

        [Fact]
        public void AccumulateFuelIfNotZero()
        {
            var calculator = new FuelCalculator();

            var fuelForFuel = calculator.CalcFuelForFuel(654);

            fuelForFuel.ShouldBe(966);
        }
    }
}
