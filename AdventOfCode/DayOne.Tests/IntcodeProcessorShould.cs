using Xunit;
using Shouldly;

namespace AdventLibrary.Tests
{
    public class IntcodeProcessorShould
    {
        [Fact]
        public void CreateArrayFromInput()
        {
            var input = "1,9,10,3,2,3,11,0,99,30,40,50";
            var intProcessor = new IntCodeProcessor(input);

            intProcessor.Code.ShouldBeOfType<int[]>();
            intProcessor.Code[0].ShouldBe(1);
            intProcessor.Code[11].ShouldBe(50);
        }

        [Fact]
        public void IdentifyAdditionCode()
        {
            var input = "1,9,10,3";
            var intProcessor = new IntCodeProcessor(input);

            OpCodes actual = intProcessor.FindOperation();

            actual.ShouldBe(OpCodes.Addition);
        }

        [Fact]
        public void IdentifyMultiplicationCode()
        {
            var input = "2,3,11,0";
            var intProcessor = new IntCodeProcessor(input);

            OpCodes actual = intProcessor.FindOperation();

            actual.ShouldBe(OpCodes.Multiplication);
        }

        [Fact]
        public void IdentifyStopCode()
        {
            var input = "99,30,40,50";
            var intProcessor = new IntCodeProcessor(input);

            OpCodes actual = intProcessor.FindOperation();

            actual.ShouldBe(OpCodes.Stop);
        }
    }
}
