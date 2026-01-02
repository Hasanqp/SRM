using MediatR;
using PRService.Application.Abstractions.Persistence;
using PRService.Domain.Entities;

namespace PRService.Application.PurchaseRequests.Commands.CreatePurchaseRequest
{
    public sealed class CreatePurchaseRequestHandler : IRequestHandler<CreatePurchaseRequestCommand, CreatePurchaseRequestResult>
    {
        public Task<CreatePurchaseRequestResult> Handle(CreatePurchaseRequestCommand request, CancellationToken cancellationToken)
        {
            // Create the Domain Entity
            var pr = new PurchaseRequest(
                request.RequestNumber,
                request.Description,
                request.TotalAmount
            );

            // later Save to DB + Publish Event

            return Task.FromResult(
                new CreatePurchaseRequestResult(
                    pr.Id,
                    pr.RequestNumber,
                    pr.Status.ToString(),
                    pr.CreatedDate
                )
            );
        }
    }
}
