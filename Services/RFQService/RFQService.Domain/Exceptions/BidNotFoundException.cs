namespace RFQService.Domain.Exceptions
{
    public sealed class BidNotFoundException : DomainException
    {
        public BidNotFoundException(Guid bidId)
            : base($"Bid with id '{bidId}' does not belong to this RFQ")
        {
        }
    }
}
