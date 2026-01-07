namespace RFQService.Application.RFQs.Queries.GetRFQDetails
{
    public sealed record RFQDetailsResult(
        Guid Id,
        Guid PurchaseRequestId,
        string Title,
        string Status,
        DateTime CreatedDate,
        Guid? WinningBidId,
        IReadOnlyCollection<BidResult> Bids
    );

    public sealed record BidResult(
        Guid Id,
        Guid SupplierId,
        decimal Amount
    );
}
