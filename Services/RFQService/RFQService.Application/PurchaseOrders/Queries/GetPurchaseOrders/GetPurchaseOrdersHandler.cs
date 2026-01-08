using MediatR;
using RFQService.Application.Abstractions.Persistence;

namespace RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrders
{
    public sealed class GetPurchaseOrdersHandler : IRequestHandler<GetPurchaseOrdersQuery, IReadOnlyCollection<PurchaseOrderResult>
    {
        private readonly IPurchaseOrderRepository _repository;

        public GetPurchaseOrdersHandler(IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyCollection<PurchaseOrderResult>> Handle(GetPurchaseOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync(cancellationToken);

            return orders
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
