namespace RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrders
{
    public sealed record PurchaseOrderResult(
        Guid Id,
        Guid RFQId,
        Guid SupplierId,
        decimal Amount,
        string Status,
        DateTime CreatedDate
    );
}
