using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2
{
    public class StringCalculator
    {
        private readonly INumbers _numbers;
        private readonly ICalculations _calculations;
        private readonly ISplit _split; 

        public StringCalculator(INumbers numbers, ICalculations calculations, ISplit split)
        {
            _numbers = numbers;
            _calculations = calculations;
            _split = split;
        }

        public int Subtract(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numbersArray = _split.SplitNumbersToArray(numbers);
            var numbersList = _numbers.ConvertStringNumbersToIntList(numbersArray);

            return _calculations.PerformCalculations(numbersList);
        }
    }
}