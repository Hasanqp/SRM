using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Entities;
using RFQService.Domain.Events;

namespace RFQService.Application.RFQs.EventHandlers
{
    public sealed class RFQAwardedDomainEventHandler : INotificationHandler<RFQAwardedDomainEvent>
    {
        private readonly IPurchaseOrderRepository _repository;

        public RFQAwardedDomainEventHandler(IPurchaseOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RFQAwardedDomainEvent notification, CancellationToken cancellationToken)
        {
            var po = PurchaseOrder.Create(
            notification.RFQId,
            notification.SupplierId,
            notification.Amount
        );

            await _repository.AddAsync(po, cancellationToken);
        }
    }
}
