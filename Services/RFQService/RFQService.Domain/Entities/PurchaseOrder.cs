using RFQService.Domain.Enums;

namespace RFQService.Domain.Entities
{
    public sealed class PurchaseOrder
    {
        public Guid Id { get; private set; }
        public Guid RFQId { get; private set; }
        public Guid SupplierId { get; private set; }
        public decimal Amount { get; private set; }
        public PurchaseOrderStatus Status { get; private set; }
        public DateTime CreatedDate { get; private set; }

        private PurchaseOrder() { }

        private PurchaseOrder(Guid rfqId, Guid supplierId, decimal amount)
        {
            Id = Guid.NewGuid();
            RFQId = rfqId;
            SupplierId = supplierId;
            Amount = amount;
            Status = PurchaseOrderStatus.Created;
            CreatedDate = DateTime.UtcNow;
        }

        public static PurchaseOrder Create(
            Guid rfqId,
            Guid supplierId,
            decimal amount)
        {
            return new PurchaseOrder(rfqId, supplierId, amount);
        }

    }
}
