using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Entities;
using RFQService.Domain.Events;

namespace RFQService.Application.RFQs.EventHandlers
{
    public sealed class RFQAwardedDomainEventHandler : INotificationHandler<RFQAwardedDomainEvent>
    {
        private readonly IRFQRepository _rFQRepository;
        private readonly IPurchaseOrderRepository _poRepository;

        public RFQAwardedDomainEventHandler(IRFQRepository rFQRepository, IPurchaseOrderRepository poRepository)
        {
            _rFQRepository = rFQRepository;
            _poRepository = poRepository;
        }
        public async Task Handle(RFQAwardedDomainEvent notification, CancellationToken cancellationToken)
        {
            var rfq = await _rFQRepository.GetByIdAsync(notification.RFQId, cancellationToken);

            var bid = rfq!.Bids
                .First(b => b.Id == notification.WinningBidId);

            var po = PurchaseOrder.Create(
                rfq.Id,
                bid.SupplierId,
                bid.Amount
            );

            await _poRepository.AddAsync(po, cancellationToken);
        }
    }
}
