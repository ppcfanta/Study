using System;
using Xunit;
using Lesson1;

namespace CalculatorTests
{
    public class UnitTestFibo
    {
        [Theory]
        [InlineData(4, 3)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(9, 34)]
        [InlineData(13, 233)]
        [InlineData(18, 2584)]
        public void TestFiboRec(int num, long expected)
        {
            var actual = Calculator.CalcFiboRecursive(num);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 3)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(9, 34)]
        [InlineData(13, 233)]
        [InlineData(18, 2584)]
        public void TestFibo(int num, long expected)
        {
            var actual = Calculator.CalcFibo(num);
            Assert.Equal(expected, actual);
        }
    }

    public class UnitTestSimple
    {
        [Theory]
        [InlineData(17, true)]
        [InlineData(29, true)]
        [InlineData(199, true)]
        [InlineData(379, true)]
        [InlineData(757, true)]
        [InlineData(69, false)]
        [InlineData(237, false)]
        [InlineData(357, false)]
        public void TestSimple(int num, bool expected)
        {
            var actual = Calculator.IsNumberSimple(num);
            Assert.Equal(expected, actual);
        }
    }
}
