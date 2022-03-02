using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class DelimitersService : IDelimiters
    {
        const string HashTags = "##";
        const string NewLine = "\n";
        const char LeftSqureBracket = '[';
        const char RightSqureBracket = ']';
        const string SquareBrackets = "][";
        const char Flag = '<';

        public List<string> GetDelimiters(string numbers)
        {
            var delimiters = new List<string>() { ",", "\n" };

            if (numbers.StartsWith(HashTags))
            {
                delimiters.AddRange(CustomDelimiter(numbers));
            }
            else if (numbers.StartsWith(Flag))
            {
                delimiters.AddRange(FlaggedDelimiter(numbers));
            }

            return delimiters;
        }

        public List<string> CustomDelimiter(string numbers)
        {
            var delimiters = new List<string>();
            var customDelimiterStartingPoint = numbers.IndexOf(HashTags) + 2;
            var customDelimiterEndingPoint = numbers.IndexOf(NewLine) - 2;
            var customDelimiter = numbers.Substring(customDelimiterStartingPoint, customDelimiterEndingPoint);

            if (customDelimiter.StartsWith(LeftSqureBracket) && customDelimiter.EndsWith(RightSqureBracket))
            {
                delimiters.AddRange(MultipleDelimiters(customDelimiter));
            }
            else
            {
                delimiters.Add(customDelimiter);
            }

            return delimiters;
        }

        public List<string> MultipleDelimiters(string delimiters)
        {
            char[] charsToTrim = { LeftSqureBracket, RightSqureBracket };
            string cleanDelimiter = delimiters.Trim(charsToTrim);
            string[] multipleDelimiter = cleanDelimiter.Split(new string[] { SquareBrackets }, StringSplitOptions.RemoveEmptyEntries);

            return multipleDelimiter.ToList();
        }

        public List<string> FlaggedDelimiter(string number)
        {
            var delimiter = number.Substring(number.IndexOf(HashTags) + 2, number.IndexOf(NewLine) - 6);
            char leftseperator = number[1];
            char rightseperator = number[number.IndexOf(HashTags) - 1];
            char[] charsToTrim = { leftseperator, rightseperator };
            string cleanDelimiter = delimiter.Trim(charsToTrim);

            return cleanDelimiter.Split(new string[] { rightseperator.ToString(), leftseperator.ToString() }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
