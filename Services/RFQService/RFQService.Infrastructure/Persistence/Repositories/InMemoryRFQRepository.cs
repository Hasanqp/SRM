using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Entities;

namespace RFQService.Infrastructure.Persistence.Repositories
{
    public sealed class InMemoryRFQRepository : IRFQRepository
    {
        private static readonly Dictionary<Guid, RFQ> _store = new();

        public Task AddAsync(RFQ rfq, CancellationToken cancellationToken)
        {
            _store[rfq.Id] = rfq;
            return Task.CompletedTask;
        }

        public Task<RFQ?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            _store.TryGetValue(id, out var rfq);
            return Task.FromResult(rfq);
        }

        public Task UpdateAsync(RFQ rfq, CancellationToken cancellationToken)
        {
            _store[rfq.Id] = rfq;
            return Task.CompletedTask;
        }
    }
}
