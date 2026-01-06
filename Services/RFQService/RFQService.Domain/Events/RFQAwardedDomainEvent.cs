namespace RFQService.Domain.Events
{
    public sealed record RFQAwardedDomainEvent(
        Guid RFQId,
        Guid WinningBidId
    );
}
