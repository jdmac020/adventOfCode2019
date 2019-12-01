using System;
using Xunit;
using Shouldly;

namespace DayOne.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            bool isFalse = true;

            isFalse.ShouldBeFalse();
        }
    }
}
