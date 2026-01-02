using PRService.Domain.Entities;

namespace PRService.Application.Abstractions.Persistence
{
    public interface IPurchaseRequestRepository
    {
        Task AddAsync(PurchaseRequest purchaseRequest, CancellationToken cancellationToken);
        Task<PurchaseRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(PurchaseRequest purchaseRequest, CancellationToken cancellationToken);
    }
}
