using RFQService.Domain.Common;

namespace RFQService.Domain.Events
{
    public sealed record RFQAwardedDomainEvent(
        Guid RFQId,
        Guid SupplierId,
        decimal Amount
    ) : IDomainEvent;
}
