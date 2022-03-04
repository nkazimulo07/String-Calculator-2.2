using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class DelimitersService : IDelimiters
    {
        public List<string> GetDelimiters(string numbers)
        {
            var delimiters = new List<string>() { ",", Constants.Constants.NewLine };

            if (numbers.StartsWith(Constants.Constants.HashTags))
            {
                delimiters.AddRange(CustomDelimiter(numbers));
            }
            else if (numbers.StartsWith(Constants.Constants.Flag))
            {
                delimiters.AddRange(FlaggedDelimiter(numbers));
            }

            return delimiters;
        }

        public List<string> CustomDelimiter(string numbers)
        {
            var delimiters = new List<string>();
            var customDelimiterStartingPoint = numbers.IndexOf(Constants.Constants.HashTags) + 2;
            var customDelimiterEndingPoint = numbers.IndexOf(Constants.Constants.NewLine) - 2;
            var customDelimiter = numbers.Substring(customDelimiterStartingPoint, customDelimiterEndingPoint);

            if (customDelimiter.StartsWith(Constants.Constants.LeftSqureBracket) && customDelimiter.EndsWith(Constants.Constants.RightSqureBracket))
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
            char[] charsToTrim = { Constants.Constants.LeftSqureBracket, Constants.Constants.RightSqureBracket };
            string cleanDelimiter = delimiters.Trim(charsToTrim);
            string[] multipleDelimiter = cleanDelimiter.Split(new string[] { Constants.Constants.SquareBrackets }, StringSplitOptions.RemoveEmptyEntries);

            return multipleDelimiter.ToList();
        }

        public List<string> FlaggedDelimiter(string number)
        {
            var delimiter = number.Substring(number.IndexOf(Constants.Constants.HashTags) + 2, number.IndexOf(Constants.Constants.NewLine) - 6);
            char leftseperator = number[1];
            char rightseperator = number[number.IndexOf(Constants.Constants.HashTags) - 1];
            char[] charsToTrim = { leftseperator, rightseperator };
            string cleanDelimiter = delimiter.Trim(charsToTrim);
            string[] flaggedDelimiter = cleanDelimiter.Split(new string[] { rightseperator.ToString(), leftseperator.ToString() }, StringSplitOptions.RemoveEmptyEntries);
            
            return flaggedDelimiter.ToList();
        }
    }
}
