using Xunit;
using Shouldly;
using System.ComponentModel;

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

        [Fact]
        public void ThrowExceptionWithBadOpCode()
        {
            var input = "4,30,40,50";
            var intProcessor = new IntCodeProcessor(input);

            Should.Throw<InvalidEnumArgumentException>(() => intProcessor.FindOperation());
        }

        [Fact]
        public void FindArgumentsToOperateOn()
        {
            var input = "1,3,3,1";
            var intProcessor = new IntCodeProcessor(input);

            (int, int) result = intProcessor.FindArguments();

            result.ShouldBe((3, 3));
        }

        [Fact]
        public void FindIndexToUpdate()
        {
            var input = "1,3,3,1";
            var intProcessor = new IntCodeProcessor(input);

            int result = intProcessor.FindUpdateIndex();

            result.ShouldBe(1);
        }

        [Fact]
        public void GenerateCodeSegment()
        {
            var input = "1,9,10,3,2,3,11,0,99,30,40,50";
            var expected = new CodeSegment
            {
                Index = 0,
                OpCode = OpCodes.Addition,
                Arguments = (9, 10),
                UpdatePosition = 3
            };
            var intProcessor = new IntCodeProcessor(input);

            CodeSegment actual = intProcessor.GenerateCodeSegment();

            actual.Index.ShouldBe(expected.Index);
            actual.OpCode.ShouldBe(expected.OpCode);
            actual.Arguments.ShouldBe(expected.Arguments);
            actual.UpdatePosition.ShouldBe(expected.UpdatePosition);
        }

        [Fact]
        public void ExecuteAdditionCodeSegment()
        {
            var input = "1,9,10,3,2,3,11,0,99,30,40,50";
            var testSegment = new CodeSegment
            {
                Index = 0,
                OpCode = OpCodes.Addition,
                Arguments = (30, 40),
                UpdatePosition = 3
            };
            int[] expected = new int[] { 1, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 };
            var intProcessor = new IntCodeProcessor(input);

            intProcessor.RunSegment(testSegment);

            intProcessor.Code.ShouldBe(expected);
        }
    }
}
