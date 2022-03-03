using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class NumbersService : INumbers
    {
        private readonly IErrorHandling _errorHandling;

        const int MaximumNumber = 1000;
        const int BigNumber = 9;

        public NumbersService(IErrorHandling errorHandling)
        {
            _errorHandling = errorHandling;
        }

        public List<int> ConvertStringsToNumbers(string[] numbers)
        {
            
            var numbersList = new List<int>();

            foreach (var number in numbers)
            {
                var temporalNumber = 0;

                if (char.IsLetter(number[0]))
                {
                    temporalNumber = ConvertCharacterToInt(char.Parse(number));
                }
                else if (char.IsLetter(number[0]))
                {
                    temporalNumber = Math.Abs(Convert.ToInt32(number));
                }

                numbersList.Add(temporalNumber);
            }

            CheckForNumbersGreaterThanOneThousand(numbersList);

            return numbersList;
        }

        public void CheckForNumbersGreaterThanOneThousand(List<int> numbersList)
        {
            var bigNumbers = "";
            var errorMessageTemplate = "You can't subtract numbers greater than 1000 :";

            foreach (var number in numbersList)
            {
                if (number > MaximumNumber)
                {
                    bigNumbers = number + " ";
                }
            }

            if (!string.IsNullOrEmpty(bigNumbers))
            {
                _errorHandling.ThrowException(errorMessageTemplate + bigNumbers);
            }
        }

        public int ConvertCharacterToInt(char alphebet)
        {
            var number = char.ToUpper(alphebet) - 65;

            if (number > BigNumber)
            {
                return 0;
            }

            return number;
        }
    }
}
