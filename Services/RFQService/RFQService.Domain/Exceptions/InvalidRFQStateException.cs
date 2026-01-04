using RFQService.Domain.Enums;

namespace RFQService.Domain.Exceptions
{
    public sealed class InvalidRFQStateException : DomainException
    {
        public RFQStatus CurrentStatus { get; }
        public RFQStatus TargetStatus { get; }

        public InvalidRFQStateException(RFQStatus currentStatus, RFQStatus targetStatus)
            : base($"Cannot transition RFQ from {currentStatus} to {targetStatus}")
        {
            CurrentStatus = currentStatus;
            TargetStatus = targetStatus;
        }
    }
}
