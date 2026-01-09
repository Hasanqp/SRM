using MediatR;
using RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrders;

namespace RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrdersByRFQId
{
    public sealed record GetPurchaseOrdersByRFQIdQuery(Guid RFQId) : IRequest<IReadOnlyCollection<PurchaseOrderResult>>;
}
