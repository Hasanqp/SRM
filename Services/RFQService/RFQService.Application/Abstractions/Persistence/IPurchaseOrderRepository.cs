using RFQService.Domain.Entities;

namespace RFQService.Application.Abstractions.Persistence
{
    public interface IPurchaseOrderRepository
    {
        Task AddAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<PurchaseOrder>> GetAllAsync(CancellationToken cancellationToken);
    }
}
