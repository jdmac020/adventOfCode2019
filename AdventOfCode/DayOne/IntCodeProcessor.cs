using System;
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
                default:
                    break;
            }
            
            return (OpCodes)99;
        }
    }

    public enum OpCodes
    {
        Addition = 1,
        Multiplication = 2,
        Stop = 99
    }
}
