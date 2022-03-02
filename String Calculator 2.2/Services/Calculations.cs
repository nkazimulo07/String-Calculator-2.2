using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class Calculations : ICalculations
    {
        public int PerformCalculation(List<int> numbers)
        {
            var difference = 0;

            foreach (var number in numbers)
            {
                difference -= number;
            }

            return difference;
        }
    }
}
