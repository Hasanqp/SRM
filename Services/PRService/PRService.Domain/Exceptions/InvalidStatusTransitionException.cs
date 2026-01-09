using PRService.Domain.Enums;

namespace PRService.Domain.Exceptions
{
    public sealed class InvalidStatusTransitionException : DomainException
    {
        public PRStatus CurrentStatus { get; }
        public PRStatus TargetStatus { get; }

        public InvalidStatusTransitionException(
            PRStatus currentStatus,
            PRStatus targetStatus)
            : base($"Cannot transition from {currentStatus} to {targetStatus}")
        {
            CurrentStatus = currentStatus;
            TargetStatus = targetStatus;
        }
    }
}
