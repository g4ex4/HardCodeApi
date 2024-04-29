namespace Application.Common.Exceptions
{
    public class ExistException : Exception
    {
        public ExistException(string name, object key)
            : base($"Entity \"{name}\" with key ({key}) is exist.") { }
    }
}
