using NSubstitute;
using NUnit.Framework;
using String_Calculator_2._2.Interfaces;
using String_Calculator_2._2.Services;
using System;
using System.Collections.Generic;

namespace StringCalculatorTest
{
    public class NumbersTest
    {
        private NumbersService _numbers;
        private IErrorHandling _errorHandlingMock;

        [SetUp]
        public void Setup()
        {
            _errorHandlingMock = Substitute.For<IErrorHandling>();
            _numbers = new NumbersService(_errorHandlingMock);
        }

        [Test]
        public void Given_StringWithNumbersGreaterThanOneThousand_When_NumbersBiggerThanOneThousand_ReturnsException()
        {
            // arrange
            var input = new List<int> { 1000, 2000, 6000 };
            string expected = "You can't subtract numbers greater than 1000 : 1000 2000 6000 ";
            _errorHandlingMock.When(_numbers => _numbers.ThrowException(Arg.Any<string>())).Do(x => throw new Exception(expected));

            //act
            var results = Assert.Throws<System.Exception>(() => _numbers.CheckForNumbersGreaterThanOneThousand(input));

            //assert
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_Character_When_ConvertingCharacterToNumber_Returns_Int()
        {
            // arrange
            char input = 'c';
            var expected = 2;

            //act
            var results = _numbers.ConvertCharacterToInt(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithLetters_When_ConvertingStringToIntegers_Returns_List()
        {
            //arrrange
            string[] input = { "a", "b", "c" };
            var expected = new List<int> { 0, 1, 2 };

            //act
            var results = _numbers.ConvertStringNumbersToIntList(input);

            //assert
            Assert.AreEqual(expected, results);
        }
    }
}
