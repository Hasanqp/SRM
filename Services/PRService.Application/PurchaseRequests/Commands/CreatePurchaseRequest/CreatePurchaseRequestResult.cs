namespace PRService.Application.PurchaseRequests.Commands.CreatePurchaseRequest
{
    public sealed record CreatePurchaseRequestResult(
        Guid Id,
        string RequestNumber,
        string Status,
        DateTime CreatedDate
    );
}
