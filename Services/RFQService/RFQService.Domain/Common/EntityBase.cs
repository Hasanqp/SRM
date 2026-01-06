namespace RFQService.Domain.Common
{
    public abstract class EntityBase
    {
        private readonly List<object> _dominEvents = new();

        public IReadOnlyCollection<object> DominEvents => _dominEvents;
        protected void AddDomainEvent(object domainEvent)
        {
            _dominEvents.Add(domainEvent);
        }

        public void ClearDomainEvent()
        {
            _dominEvents.Clear();
        }
    }
}
