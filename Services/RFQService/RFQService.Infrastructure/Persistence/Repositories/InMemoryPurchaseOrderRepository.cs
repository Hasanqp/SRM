using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Entities;

namespace RFQService.Infrastructure.Persistence.Repositories
{
    public sealed class InMemoryPurchaseOrderRepository : IPurchaseOrderRepository
    {
        private static readonly List<PurchaseOrder> _store = new();

        public Task AddAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken)
        {
            _store.Add(purchaseOrder);
            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<PurchaseOrder>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyCollection<PurchaseOrder>>(
                _store.AsReadOnly());
        }
    }
}
