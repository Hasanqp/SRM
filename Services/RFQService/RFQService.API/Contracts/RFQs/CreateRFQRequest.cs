namespace RFQService.API.Contracts.RFQs
{
    public sealed record CreateRFQRequest(
        Guid PurchaseRequestId,
        string Title
    );
}
