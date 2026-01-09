namespace PRService.Application.PurchaseRequests.Queries.GetPurchaseRequestById
{
    public sealed record PurchaseRequestResult(
        Guid Id,
        string RequestNumber,
        string Description,
        decimal TotalAmount,
        string Status,
        DateTime CreatedDate
    );
}
