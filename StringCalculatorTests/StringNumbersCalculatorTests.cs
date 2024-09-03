namespace StringCalculatorTests
{
    using StringNumbersCalculator;
    using Xunit;

    public class StringNumbersCalculatorTests
    {
        [Fact]
        public void EmptyString_ReturnsZero()
        {
            Assert.Equal(0, Program.Add(""));
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void SingleNumber_ReturnsNumber(string numbers, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.Add(numbers));
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1\n2\n3", 6)]
        [InlineData("//;\n1;2;3", 6)]
        [InlineData("//|\n1|2|3", 6)]
        public void MultipleNumbers_ReturnsSum(string numbers, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.Add(numbers));
        }

        [Theory]
        [InlineData("-1", "Negatives not allowed: -1")]
        [InlineData("1,-2,3", "Negatives not allowed: -2")]
        public void NegativeNumbers_ThrowsArgumentException(string numbers, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => Program.Add(numbers));
            Assert.Equal(expectedMessage, ex.Message);

        }
    }
}