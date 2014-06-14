using Ploeh.AutoFixture;
using Should;
using NUnit.Framework;

namespace StringCalculator.UnitTests
{
    public class CalculatorTests
    {
        private static Fixture Fixture = new Fixture();
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

        [Test]
        public void Single_number_returns_number()
        {
            var value = Fixture.Create<int>();
            _sut.Add(value.ToString()).ShouldEqual(value);
        }

        [Test]
        public void A_string_containing_1_and_2_returns_3()
        {
            _sut.Add("1,2").ShouldEqual(3);
        }

    }
}
