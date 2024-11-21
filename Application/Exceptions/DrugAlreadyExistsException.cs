namespace Application.Exceptions
{
    public class DrugAlreadyExistsException : Exception
    {
        public DrugAlreadyExistsException()
            : base("Лекарство с данным именем уже имеется в системе.")
        {
        }

        public DrugAlreadyExistsException(string message)
            : base(message)
        {
        }

        public DrugAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}