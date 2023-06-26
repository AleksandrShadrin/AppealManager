namespace AppealManager.Application.Exceptions
{
    public class ParseException : ApplicationBaseException
    {
        public ParseException(string line)
            : base($"Невозможно прочитать строку: {line}.")
        {
        }
    }
}
