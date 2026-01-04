namespace PRService.Domain.Exceptions
{
    public sealed class NotFoundException : DomainException
    {
        public NotFoundException(string entity, string id)
            : base($"{entity} with id '{id}' was not found")
        {
            
        }
    }
}
