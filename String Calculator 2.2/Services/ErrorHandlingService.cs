using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class ErrorHandlingService : IErrorHandling
    {
        public void ThrowNumbersTooLargeException(string bigNumbers)
        {
            throw new Exception(Constants.Constants.errorMessageTemplate + bigNumbers);
        }
    }
}
