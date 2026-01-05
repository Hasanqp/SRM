using RFQService.Domain.Enums;
using RFQService.Domain.Exceptions;

namespace RFQService.Domain.Entities
{
    public sealed class RFQ
    {
        private readonly List<Bid> _bids = new();
        public IReadOnlyCollection<Bid> Bids => _bids.AsReadOnly();

        public Guid Id { get; private set; }
        public Guid PurchaseRequestId { get; private set; }
        public string Title { get; private set; }
        public RFQStatus Status { get; private set; }
        public DateTime CreatedDate { get; private set; }

        private RFQ() { }

        private RFQ(Guid purchaseRequestId, string title)
        {
            Id = Guid.NewGuid();
            PurchaseRequestId = purchaseRequestId;
            Title = title;
            Status = RFQStatus.Draft;
            CreatedDate = DateTime.UtcNow;
        }

        public static RFQ Create(Guid purchaseRequestId, string title)
        {
            return new RFQ(purchaseRequestId, title);
        }

        public void SendToVendors()
        {
            if (Status != RFQStatus.Draft)
                throw new InvalidRFQStateException(Status, RFQStatus.SentToVendors);

            Status = RFQStatus.SentToVendors;
        }

        public void Close()
        {
            if (Status != RFQStatus.SentToVendors)
                throw new InvalidRFQStateException(Status, RFQStatus.Closed);

            Status = RFQStatus.Closed;
        }

        public void Cancel()
        {
            if (Status == RFQStatus.Closed)
                throw new InvalidRFQStateException(Status, RFQStatus.Cancelled);

            Status = RFQStatus.Cancelled;
        }

        public void SubmitBid(Guid supplierId, decimal amount)
        {
            if (Status != RFQStatus.SentToVendors)
                throw new InvalidRFQStateException(
                    Status,
                    RFQStatus.SentToVendors);

            _bids.Add(new Bid(supplierId, amount));
        }
    }
}
