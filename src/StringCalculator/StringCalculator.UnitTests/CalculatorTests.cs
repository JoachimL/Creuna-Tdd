using Should;
using NUnit.Framework;

namespace StringCalculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Calculator();
        }

        [Test]
        public void An_empty_string_returns_0()
        {
            _sut.Add(string.Empty).ShouldEqual(0);
        }
    }
}
