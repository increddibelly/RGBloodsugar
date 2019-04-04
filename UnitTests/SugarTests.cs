using FluentAssertions;
using LedScout.Control;
using LedScout.Model;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class SugarTests
    {
        [TestCase(1.0, BloodSugarState.VeryLow)]
        [TestCase(3.5, BloodSugarState.Low)]
        [TestCase(6.5, BloodSugarState.InRange)]
        [TestCase(10.0, BloodSugarState.High)]
        [TestCase(20.0, BloodSugarState.VeryHigh)]
        public void ShouldGetRangeRight(decimal input, BloodSugarState expected)
        {
            // arrange
            var evt = new BloodSugarEvent{BloodSugarLevel=input};

            // act
            var result = SugarStateFinder.Get(evt);

            // assert
            result.Should().Be(expected);
        }
    }
}
