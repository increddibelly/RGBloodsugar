using FluentAssertions;
using LedScout.Model;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ColorTests
    {
        [TestCase("FF0000", 255,   0,   0)]
        [TestCase("00FF00", 0,   255,   0)]
        [TestCase("0000FF", 0,     0, 255)]
        [TestCase("123456", 18,   52,  86)]
        public void ShouldParseColors(string input, int expectedRed, int expectedGreen, int expectedBlue)
        {
            // arrange

            // act
            var result = new Color(input);

            // assert
            result.Red.Should().Be(expectedRed);
            result.Green.Should().Be(expectedGreen);
            result.Blue.Should().Be(expectedBlue);
        }

        [TestCase(255, 100)]
        [TestCase(0, 0)]
        [TestCase(128, 50)]
        [TestCase(127, 49)]
        public void ShouldGetPercentageRight(int input, int expected)
        {
            // arrange

            // act
            var result = input.ToPct();

            // assert
            result.Should().Be(expected);
        }
    }
}
