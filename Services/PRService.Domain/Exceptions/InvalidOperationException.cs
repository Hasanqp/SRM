namespace PRService.Domain.Exceptions
{
    public class InvalidOperationException : DomainException
    {
        public InvalidOperationException(string operation, string reason)
            : base($"Operation '{operation}' is invalid: {reason}")
        {
        }
    }
}
