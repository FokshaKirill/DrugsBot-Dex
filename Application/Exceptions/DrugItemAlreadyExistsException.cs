namespace Application.Exceptions
{
    public class DrugItemAlreadyExistsException : Exception
    {
        public DrugItemAlreadyExistsException()
            : base("Товар с данным именем уже имеется в системе.")
        {
        }

        public DrugItemAlreadyExistsException(string message)
            : base(message)
        {
        }

        public DrugItemAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}