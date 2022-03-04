using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class SplitService : ISplit
    {
        private readonly IDelimiters _delimiters;

        public SplitService(IDelimiters delimiters)
        {
            _delimiters = delimiters;
        }

        public string[] SplitNumbers(string numbers)
        {
            var delimiters = _delimiters.GetDelimiters(numbers);

            if (numbers.StartsWith(Constants.Constants.HashTags))
            {
                numbers = numbers.Substring(numbers.LastIndexOf(Constants.Constants.NewLine) + 1);

            }

            return numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
        }
    }
}
