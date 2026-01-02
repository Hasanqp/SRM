using MediatR;
using PRService.Application.Abstractions.Persistence;
using PRService.Domain.Exceptions;

namespace PRService.Application.PurchaseRequests.Commands.SubmitPurchaseRequest
{
    public sealed class SubmitPurchaseRequestHandler : IRequestHandler<SubmitPurchaseRequestCommand>
    {
        private readonly IPurchaseRequestRepository _repository;

        public SubmitPurchaseRequestHandler(IPurchaseRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(SubmitPurchaseRequestCommand request, CancellationToken cancellationToken)
        {
            var pr = await _repository.GetByIdAsync(
                request.PurchaseRequestId,
                cancellationToken
            );

            if (pr is null)
            {
                throw new Domain.Exceptions.InvalidOperationException(
                    "Submit PR",
                    "Purchase request not found");
            }

            // Domain enforces business rules
            pr.Submit();

            await _repository.UpdateAsync(pr, cancellationToken);
        }
    }
}
