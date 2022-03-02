using NSubstitute;
using NUnit.Framework;
using String_Calculator_2._2.Interfaces;
using String_Calculator_2._2.Services;
using System.Collections.Generic;

namespace String_Calculator_Tests
{

    public class SplitNumbersTest
    {
        private SplitService _split;
        private IDelimiters _delimitersMock;

        [SetUp]
        public void Setup()
        {
            _delimitersMock = Substitute.For<IDelimiters>();
            _split = new SplitService(_delimitersMock);
        }

        [Test]
        public void Given_StringNumbers_When_SplitingNumbers_Returns_NumbersArray()
        {
            //arrange
            const string input = "1,2";
            var delimiters = new List<string>() { ",", "\n" };
            string[] expected = { "1", "2" };

            _delimitersMock.GetDelimiters(Arg.Any<string>()).Returns(delimiters);

            //act
            var results = _split.SplitNumbersToArray(input);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}
