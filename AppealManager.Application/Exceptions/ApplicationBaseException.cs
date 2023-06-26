namespace AppealManager.Application.Exceptions
{
    public class ApplicationBaseException : Exception
    {
        protected ApplicationBaseException(string message) 
            : base(message)
        {
        }
    }
}
