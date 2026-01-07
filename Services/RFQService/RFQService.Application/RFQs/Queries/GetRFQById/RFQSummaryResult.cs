namespace RFQService.Application.RFQs.Queries.GetRFQById
{
    public sealed record RFQSummaryResult(
        Guid Id,
        Guid PurcahseRequestId,
        string Title,
        string Status,
        DateTime CreatedDate,
        IReadOnlyCollection<BidResult> Bids
    );
}
