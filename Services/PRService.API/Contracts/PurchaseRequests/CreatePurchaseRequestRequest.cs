namespace PRService.API.Contracts.PurchaseRequests
{
    public sealed record CreatePurchaseRequestRequest(
        string RequestNumber,
        string Description,
        decimal TotalAmount
    );
}
