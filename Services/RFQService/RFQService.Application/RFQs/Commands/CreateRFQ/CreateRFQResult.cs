namespace RFQService.Application.RFQs.Commands.CreateRFQ
{
    public sealed record CreateRFQResult(
        Guid Id,
        Guid PurchaseRequestId,
        String Status,
        DateTime CreateDate
    );
}
