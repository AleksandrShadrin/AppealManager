namespace AppealManager.Application.Exceptions
{
    public class EmptyContractorsException : ApplicationBaseException
    {
        public EmptyContractorsException() 
            : base("Исполнителей должно быть не менее одного человека.")
        {
        }
    }
}