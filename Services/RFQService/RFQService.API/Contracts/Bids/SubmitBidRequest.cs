namespace RFQService.API.Contracts.Bids
{
    public sealed record SubmitBidRequest(
        Guid SupplierId,
        decimal Amount
    );
}
