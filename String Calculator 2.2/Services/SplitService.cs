using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class SplitService : ISplit
    {
        private readonly IDelimiters _delimiters;

        const string HashTags = "##";
        const string NewLine = "\n";

        public SplitService(IDelimiters delimiters)
        {
            _delimiters = delimiters;
        }

        public string[] SplitNumbers(string numbers)
        {
            var delimiters = _delimiters.GetDelimiters(numbers);

            if (numbers.StartsWith(HashTags))
            {
                numbers = numbers.Substring(numbers.LastIndexOf(NewLine) + 1);

            }

            return numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
        }
    }
}
