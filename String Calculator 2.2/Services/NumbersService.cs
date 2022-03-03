using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class NumbersService : INumbers
    {
        private readonly IErrorHandling _errorHandling;

        const int MaximumNumber = 1000;
        const int bigNumber = 9;
        public NumbersService(IErrorHandling errorHandling)
        {
            _errorHandling = errorHandling;
        }

        public List<int> ConvertStringsNumbers(string[] numbers)
        {
            bool isNumeric = true;
            var numbersList = new List<int>();
            var temporalNumber = 0;

            foreach (var number in numbers)
            {
                isNumeric = int.TryParse(number, out int _);

                if (!isNumeric)
                {
                    temporalNumber = ConvertCharacterToInt(char.Parse(number));
                }
                else
                {
                    temporalNumber = Math.Abs(Convert.ToInt32(number));
                }

                numbersList.Add(Math.Abs(temporalNumber));
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

            if (number > bigNumber)
            {
                return 0;
            }

            return number;
        }
    }
}
