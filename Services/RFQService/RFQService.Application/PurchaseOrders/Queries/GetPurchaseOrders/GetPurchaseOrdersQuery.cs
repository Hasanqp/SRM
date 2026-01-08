using MediatR;

namespace RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrders
{
    public sealed record GetPurchaseOrdersQuery : IRequest<IReadOnlyCollection<PurchaseOrderResult>>;
}
