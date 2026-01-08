using RFQService.Domain.Entities;

namespace RFQService.Application.Abstractions.Persistence
{
    public interface IRFQRepository
    {
        Task AddAsync(RFQ rfq, CancellationToken cancellationToken);
        Task<RFQ?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(RFQ rfq, CancellationToken cancellationToken);

    }
}
