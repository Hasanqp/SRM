using PRService.Domain.Common;
using PRService.Domain.Enums;
using PRService.Domain.Exceptions;

namespace PRService.Domain.Entities
{
    public class PurchaseRequest : EntityBase
    {
        public Guid Id { get; private set; }
        public string RequestNumber { get; private set; }
        public string Description { get; private set; }
        public decimal TotalAmount { get; private set; }
        public PRStatus Status { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? SubmittedDate { get; private set; }
        public DateTime? ApprovedDate { get; private set; }
        public DateTime? RejectedDate { get; private set; }
        public string? RejectionReason { get; private set; }

        public PurchaseRequest(string requestNumber, string description, decimal totalAmount)
        {
            Id = Guid.NewGuid();
            RequestNumber = requestNumber ?? throw new ArgumentNullException(nameof(requestNumber));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            TotalAmount = totalAmount > 0 ? totalAmount :
                throw new Exceptions.InvalidOperationException(
                    "Create PR", "Total amount must be greater than 0");

            Status = PRStatus.Draft;
            CreatedDate = DateTime.UtcNow;
        }

        // Business Methods with Rules Enforcement

        public void Submit()
        {
            // Rule Submit allowed only from Draft
            if (Status != PRStatus.Draft)
            {
                throw new InvalidStatusTransitionException(Status, PRStatus.Submitted);
            }

            // Rule Validate before submission
            ValidateBeforeSubmission();

            Status = PRStatus.Submitted;
            SubmittedDate = DateTime.UtcNow;

            // Domain Event
            // AddDomainEvent(new PurchaseRequestSubmittedEvent(this));
        }

        public void Approve()
        {
            // Rule Approve allowed only from Submitted
            if (Status != PRStatus.Submitted)
            {
                throw new InvalidStatusTransitionException(Status, PRStatus.Approved);
            }

            // Rule Additional validation for approval
            if (TotalAmount > 100000) // For example for a little amounts
            {
                throw new Exceptions.InvalidOperationException(
                    "Approve", "Requires additional approval for amounts over 100,000");
            }

            Status = PRStatus.Approved;
            ApprovedDate = DateTime.UtcNow;
        }

        public void Reject(string reason)
        {
            // Rule Reject allowed only from Submitted
            if (Status != PRStatus.Submitted)
            {
                throw new InvalidStatusTransitionException(Status, PRStatus.Rejected);
            }

            // Rule Rejection reason is required
            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new Exceptions.InvalidOperationException(
                    "Reject", "Rejection reason is required");
            }

            Status = PRStatus.Rejected;
            RejectionReason = reason;
            RejectedDate = DateTime.UtcNow;
        }

        // Private validation methods
        private void ValidateBeforeSubmission()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Description) || Description.Length < 10)
            {
                errors.Add(
                    "Description must be at least 10 characters");
            }

            if (TotalAmount <= 0)
            {
                errors.Add(
                    "Total amount must be greater than 0");
            }

            if (errors.Any())
            {
                throw new Exceptions.InvalidOperationException(
                    "Submit", $"Validation failed: {string.Join(", ", errors)}");
            }
        }

        // Additional business methods
        public void UpdateDescription(string newDescription)
        {
            // Rule Can only update description in Draft status
            if (Status != PRStatus.Draft)
            {
                throw new Exceptions.InvalidOperationException(
                    "Update", "Can only update description in Draft status");
            }

            Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
        }

        public void UpdateAmount(decimal newAmount)
        {
            // Rule Can only update amount in Draft status
            if (Status != PRStatus.Draft)
            {
                throw new Exceptions.InvalidOperationException(
                    "Update", "Can only update amount in Draft status");
            }

            if (newAmount <= 0)
            {
                throw new Exceptions.InvalidOperationException(
                    "Update", "Amount must be greater than 0");
            }

            TotalAmount = newAmount;
        }
    }
}
