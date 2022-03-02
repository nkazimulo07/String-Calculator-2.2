using NUnit.Framework;
using String_Calculator_2._2.Services;
using System.Collections.Generic;

namespace String_Calculator_Tests
{
    public class CalculationsTest
    {
        private Calculations _calculations;

        [SetUp]
        public void Setup()
        {
            _calculations = new Calculations();
        }

        [Test]
        public void Given_ListOfNumbers_When_Calculating_Returns_Difference()
        {
            //assert
            var input = new List<int>() { 60, 800, 1};
            const int expected = -861;

            //act
            var results = _calculations.PerformCalculations(input);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}
