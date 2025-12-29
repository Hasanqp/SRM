using PRService.Domain.Enums;

namespace PRService.Domain.Entities
{
    public class PurchaseRequest
    {
        public int Id { get; set; }
        public string RequestNumber { get; set; }
        public PRStatus Status { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
