namespace RFQService.Application.RFQs.Queries.GetRFQById
{
    public sealed record BidResult(
        Guid Id,
        Guid SupplierId,
        decimal Amount,
        DateTime SubmittedDate
    );
}
