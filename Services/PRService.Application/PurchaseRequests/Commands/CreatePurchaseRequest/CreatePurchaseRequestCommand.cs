namespace PRService.Application.PurchaseRequests.Commands.CreatePurchaseRequest
{
    public sealed record CreatePurchaseRequestCommand(
        string RequestNumber,
        string Description,
        decimal TotalAmount
    );
}
