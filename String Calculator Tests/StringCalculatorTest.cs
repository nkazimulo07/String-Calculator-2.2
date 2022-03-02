using NSubstitute;
using NUnit.Framework;
using String_Calculator_2._2;
using String_Calculator_2._2.Interfaces;
using System.Collections.Generic;

namespace String_Calculator_Tests
{
    public class Tests
    {
        private StringCalculator _calculator;
        private INumbers _numbersMock;
        private ICalculations _calculationsMock;
        private ISplit _splitMock;

        [SetUp]
        public void Setup()
        {
            _numbersMock = Substitute.For<INumbers>();
            _calculationsMock = Substitute.For<ICalculations>();
            _splitMock = Substitute.For<ISplit>();
            _calculator = new StringCalculator(_numbersMock, _calculationsMock, _splitMock);
        }

        [Test]
        public void Given_EmptyString_When_Subtracting_Return_Zero()
        {
            //assert
            const string input = "";
            const int expected = 0;

            //act
            var results = _calculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithOneNumber_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "1";
            const int expected = -1;
            string[] numbersStringArray = { "1" };
            var numbersList = new List<int>() { 1 };

            _splitMock.SplitNumbersToArray(Arg.Any<string>()).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToIntList(Arg.Any<string[]>()).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);

            //act
            var results = _calculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithTwoNumbers_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "1,2";
            const int expected = -3;
            string[] numbersStringArray = { "1", "2" };
            var numbersList = new List<int>() { 1, 2 };

            _splitMock.SplitNumbersToArray(Arg.Any<string>()).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToIntList(Arg.Any<string[]>()).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);

            //act
            var results = _calculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithNewLineAsDelimiter_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "1\n2,3";
            const int expected = -6;
            string[] numbersStringArray = { "1", "2", "3"};
            var numbersList = new List<int>() { 1, 2, 3};

            _splitMock.SplitNumbersToArray(Arg.Any<string>()).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToIntList(Arg.Any<string[]>()).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);

            //act
            var results = _calculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringCustomDelimiter_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "##;\n1;2";
            const int expected = -3;
            string[] numbersStringArray = { "1", "2" };
            var numbersList = new List<int>() { 1, 2 };

            _splitMock.SplitNumbersToArray(Arg.Any<string>()).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToIntList(Arg.Any<string[]>()).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);

            //act
            var results = _calculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithDelimiterThatHasLengthOfThree_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "##***\n1***2";
            const int expected = -3;
            string[] numbersStringArray = { "1", "2" };
            var numbersList = new List<int>() { 1, 2 };

            _splitMock.SplitNumbersToArray(Arg.Any<string>()).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToIntList(Arg.Any<string[]>()).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);

            //act
            var results = _calculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithLetters_When_Subtracting_Return_Difference()
        {
            //assert
            const string input = "i,j,k";
            const int expected = -17;
            string[] numbersStringArray = { "1", "2" };
            var numbersList = new List<int>() { 1, 2 };

            _splitMock.SplitNumbersToArray(Arg.Any<string>()).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumbersToIntList(Arg.Any<string[]>()).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);

            //act
            var results = _calculator.Subtract(input);

            //assert
            Assert.AreEqual(expected, results);
        }

    }
}