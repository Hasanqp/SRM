using PRService.Application.Abstractions.Persistence;
using PRService.Domain.Entities;

namespace PRService.Infrastructure.Persistence.Repositories
{
    public sealed class InMemoryPurchaseRequestRepository : IPurchaseRequestRepository
    {
        private static readonly Dictionary<Guid, PurchaseRequest> _store = new();

        public Task AddAsync(PurchaseRequest purchaseRequest, CancellationToken cancellationToken)
        {
            _store[purchaseRequest.Id] = purchaseRequest;
            return Task.CompletedTask;
        }

        public Task<PurchaseRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            _store.TryGetValue(id, out var pr);
            return Task.FromResult(pr);
        }

        public Task UpdateAsync(PurchaseRequest purchaseRequest, CancellationToken cancellationToken)
        {
            _store[purchaseRequest.Id] = purchaseRequest;
            return Task.CompletedTask;
        }
    }
}
