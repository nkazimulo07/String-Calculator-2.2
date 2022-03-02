using String_Calculator_2._2.Interfaces;

namespace String_Calculator_2._2.Services
{
    public class ErrorHandlingService : IErrorHandling
    {
        public void ThrowException(string exceptionMessage)
        {
            throw new Exception(exceptionMessage);
        }
    }
}
