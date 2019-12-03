﻿using System;
using System.ComponentModel;
using System.Linq;

namespace AdventLibrary
{
    public class IntCodeProcessor
    {
        public int[] Code { get; }

        private const int ARG_ONE_ADJUST = 1;
        private const int ARG_TWO_ADJUST = 2;
        private const int UPDATE_POS_ADJUST = 3;

        public IntCodeProcessor(string input)
        {
            var split = input.Split(',');
            Code = split.Select(item => int.Parse(item)).ToArray();
        }

        public OpCodes FindOperation(int startPosition)
        {
            var valueAtZero = Code[startPosition];

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

        public (int, int) FindArguments(int startPosition)
        {
            return (Code[startPosition + ARG_ONE_ADJUST],Code[startPosition + ARG_TWO_ADJUST]);
        }

        public int FindUpdateIndex(int startPosition)
        {
            return Code[startPosition + UPDATE_POS_ADJUST];
        }

        public CodeSegment GenerateCodeSegment(int startPosition)
        {
            return new CodeSegment
            {
                Index = startPosition,
                OpCode = FindOperation(startPosition),
                Arguments = FindArguments(startPosition),
                UpdatePosition = FindUpdateIndex(startPosition)
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

        public void RunIntCode()
        {
            
        }
    }

    public enum OpCodes
    {
        Addition = 1,
        Multiplication = 2,
        Stop = 99
    }
}
