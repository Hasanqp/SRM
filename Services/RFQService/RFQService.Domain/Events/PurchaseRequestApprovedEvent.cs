namespace RFQService.Domain.Events
{
    public sealed record PurchaseRequestApprovedEvent(
        Guid PurchaseRequestId,
        string Title
        );
}
