using MediatR;
using PRService.Application.Abstractions.Persistence;

namespace PRService.Application.PurchaseRequests.Commands.ApprovePurchaseRequest
{
    public sealed class ApprovePurchaseRequestHandler : IRequestHandler<ApprovePurchaseRequestCommand>
    {
        private readonly IPurchaseRequestRepository _repository;

        public ApprovePurchaseRequestHandler(IPurchaseRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(ApprovePurchaseRequestCommand request, CancellationToken cancellationToken)
        {
            var pr = await _repository.GetByIdAsync(
                request.PurchaseRequestId, cancellationToken);

            if (pr is null)
            {
                throw new Domain.Exceptions.InvalidOperationException(
                    "Approve PR",
                    "Purchase request not found"
                );
            }

            // Domain enforces business rules
            pr.Approve();

            await _repository.UpdateAsync(pr, cancellationToken);
        }
    }
}
