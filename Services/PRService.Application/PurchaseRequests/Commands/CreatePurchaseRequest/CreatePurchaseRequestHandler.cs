using PRService.Application.Abstractions.Persistence;
using PRService.Domain.Entities;

namespace PRService.Application.PurchaseRequests.Commands.CreatePurchaseRequest
{
    public sealed class CreatePurchaseRequestHandler
    {
        private readonly IPurchaseRequestRepository _repository;

        public CreatePurchaseRequestHandler(IPurchaseRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreatePurchaseRequestCommand command, CancellationToken cancellationToken)
        {
            var purchaseRequest = new PurchaseRequest(
                command.RequestNumber,
                command.Description,
                command.TotalAmount
            );

            await _repository.AddAsync(purchaseRequest, cancellationToken);

            return purchaseRequest.Id;
        }
    }
}
