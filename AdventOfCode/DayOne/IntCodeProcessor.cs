using System;
using System.ComponentModel;
using System.Linq;

namespace AdventLibrary
{
    public class IntCodeProcessor
    {
        public int[] Code { get; }

        public IntCodeProcessor(string input)
        {
            var split = input.Split(',');
            Code = split.Select(item => int.Parse(item)).ToArray();
        }

        public OpCodes FindOperation()
        {
            var valueAtZero = Code[0];

            switch (valueAtZero)
            {
                case (int)OpCodes.Addition:
                    return OpCodes.Addition;
                case (int)OpCodes.Multiplication:
                    return OpCodes.Multiplication;
                case (int)OpCodes.Stop:
                    return OpCodes.Stop;
                default:
                    throw new InvalidEnumArgumentException("OpCode", valueAtZero, typeof(OpCodes));
            }
        }

        public (int, int) FindArguments()
        {
            return (Code[1],Code[2]);
        }

        public int FindUpdateIndex()
        {
            return Code[3];
        }

        public CodeSegment GenerateCodeSegment()
        {
            return new CodeSegment
            {
                Index = 0,
                OpCode = FindOperation(),
                Arguments = FindArguments(),
                UpdatePosition = FindUpdateIndex()
            };
        }

        public void RunSegment(CodeSegment segment)
        {
            switch (segment.OpCode)
            {
                case OpCodes.Addition:
                    var args = segment.Arguments;
                    var result = args.Item1 + args.Item2;
                    Code[segment.UpdatePosition] = result;
                    break;
                case OpCodes.Multiplication:
                    args = segment.Arguments;
                    result = args.Item1 * args.Item2;
                    Code[segment.UpdatePosition] = result;
                    break;
                case OpCodes.Stop:
                default:
                    break;
            }
        }
    }

    public enum OpCodes
    {
        Addition = 1,
        Multiplication = 2,
        Stop = 99
    }
}
