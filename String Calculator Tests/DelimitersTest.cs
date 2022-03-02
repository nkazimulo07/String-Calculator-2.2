using NUnit.Framework;
using String_Calculator_2._2.Services;
using System.Collections.Generic;

namespace String_Calculator_Tests
{
    public class DelimitersTest
    {
        private DelimitersService _delimiters;

        [SetUp]
        public void Setup()
        {
            _delimiters = new DelimitersService();
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingDelimeter_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "##[*][%][:][;]\n";
            var expected = new List<string> { ",", "\n", "*", "%", ":", ";" };

            // act 
            var results = _delimiters.GetDelimiters(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingGetMultipleDelimeters_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "[*][%][:][;]";
            var expected = new List<string> { "*", "%", ":", ";" };

            // act 
            var results = _delimiters.MultipleDelimiters(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithFlaggedDelimiter_UsingFlaggedDelimiter_ResultsReturnsDelimiterList()
        {
            // arrange
            const string input = "<(>)##(*)\n1*2*3";
            var expected = new List<string> { "*" };

            // act 
            var results = _delimiters.FlaggedDelimiter(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhentringWithFlaggedDelimiters_UsingFlaggedDelimiter_ResultsReturnsDelimiterList()
        {
            // arrange
            const string input = "<[>}##[::}[;}\n1::2;3";
            var expected = new List<string> { "::", ";" };

            // act 
            var results = _delimiters.FlaggedDelimiter(input);

            // assert
            Assert.AreEqual(expected, results);
        }
    }
}
