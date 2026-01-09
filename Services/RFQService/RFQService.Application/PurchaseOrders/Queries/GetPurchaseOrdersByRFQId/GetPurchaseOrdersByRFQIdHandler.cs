using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrders;

namespace RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrdersByRFQId
{
    public sealed class GetPurchaseOrdersByRFQIdHandler : IRequestHandler<GetPurchaseOrdersByRFQIdQuery, IReadOnlyCollection<PurchaseOrderResult>>
    {
        private readonly IPurchaseOrderRepository _repository;

        public GetPurchaseOrdersByRFQIdHandler(IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyCollection<PurchaseOrderResult>> Handle(GetPurchaseOrdersByRFQIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync(cancellationToken);

            return orders
                .Where(po => po.RFQId == request.RFQId)
                .Select(po => new PurchaseOrderResult(
                    po.Id,
                    po.RFQId,
                    po.SupplierId,
                    po.Amount,
                    po.Status.ToString(),
                    po.CreatedDate))
                .ToList();
        }
    }
}
