using System;
using System.Linq;
using Moq;
using Ploeh.AutoFixture;
using Should;
using NUnit.Framework;

namespace StringCalculator.UnitTests
{
    public class CalculatorTests
    {
        private static Fixture Fixture = new Fixture();
        private Mock<ICalculationAggregator> _calculationAggregatorMock;
        private Calculator _sut;

        [SetUp]
        public void SetUp()
        {
            _calculationAggregatorMock = new Mock<ICalculationAggregator>();
            _calculationAggregatorMock.Setup(c => c.PostResults(It.IsAny<int>())).Returns(true);
            _sut = new Calculator(_calculationAggregatorMock.Object);
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

        [Test]
        public void Arbitray_number_of_comma_separated_numbers_returns_the_sum_of_the_numbers()
        {
            var numbers = Fixture.CreateMany<int>();
            _sut.Add(string.Join(",", numbers)).ShouldEqual(numbers.Sum());
        }

        [Test]
        public void Numbers_can_be_delimited_by_line_breaks()
        {
            var numbers = "1" + Environment.NewLine + "2";
            _sut.Add(numbers).ShouldEqual(3);
        }

        [Test]
        public void First_line_can_change_delimiter()
        {
            var delimiter = Fixture.Create<string>();
            var numbers = Fixture.CreateMany<int>();
            var numberLine = string.Join(delimiter, numbers);
            _sut.Add(string.Concat("//", delimiter, Environment.NewLine, numberLine)).ShouldEqual(numbers.Sum());
        }

        [Test]
        public void Semicolon_can_be_used_as_delimiter()
        {
            _sut.Add(string.Concat("//;", Environment.NewLine, "2;2")).ShouldEqual(4);
        }

        [Test]
        [ExpectedException]
        public void An_exception_is_thrown_if_the_calculation_aggregator_post_returns_false()
        {
            _calculationAggregatorMock
                .Setup(c => c.PostResults(It.IsAny<int>()))
                .Returns(false);
            _sut.Add("1");
        }
    }
}
