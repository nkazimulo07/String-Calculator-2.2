using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class NumbersService : INumbers
    {
        private readonly IErrorHandling _errorHandling;

        public NumbersService(IErrorHandling errorHandling)
        {
            _errorHandling = errorHandling;
        }

        public List<int> ConvertStringNumbersToIntList(string[] numbers)
        {
            bool isNumeric = true;
            var numbersList = new List<int>();
            var tempNumber = 0;

            foreach (var number in numbers)
            {
                isNumeric = int.TryParse(number, out int _);

                if (!isNumeric)
                {
                    tempNumber = ConvertCharacterToInt(char.Parse(number));
                }
                else
                {
                    tempNumber = Math.Abs(Convert.ToInt32(number));
                }

                numbersList.Add(Math.Abs(tempNumber));
            }

            CheckForNumbersGreaterThanOneThousand(numbersList);

            return numbersList;
        }

        public void CheckForNumbersGreaterThanOneThousand(List<int> numbersList)
        {
            var bigNumbers = "";
            var errorMessage = "You can't subtract numbers greater than 1000 :";

            foreach (var number in numbersList)
            {
                if (number > 1000)
                {
                    bigNumbers = number + " ";
                }
            }

            if (!string.IsNullOrEmpty(bigNumbers))
            {
                _errorHandling.ThrowException(errorMessage + bigNumbers);
            }
        }

        public int ConvertCharacterToInt(char alphebet)
        {
            var number = char.ToUpper(alphebet) - 65;

            if (number > 9)
            {
                return 0;
            }

            return number;
        }
    }
}
