namespace RFQService.Domain.Entities
{
    public sealed class Bid
    {
        public Guid Id { get; private set; }
        public Guid SupplierId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime SubmittedDate { get; private set; }

        private Bid() { }

        internal Bid(Guid supplierId, decimal amount)
        {
            Id = Guid.NewGuid();
            SupplierId = supplierId;
            Amount = amount;
            SubmittedDate = DateTime.UtcNow;
        }
    }
}
