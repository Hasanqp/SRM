using MediatR;
using PRService.Application.Abstractions.Persistence;

namespace PRService.Application.PurchaseRequests.Commands.RejectPurchaseRequest
{
    public sealed class RejectPurchaseRequestHandler : IRequestHandler<RejectPurchaseRequestCommand>
    {
        private readonly IPurchaseRequestRepository _repository;

        public RejectPurchaseRequestHandler(IPurchaseRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RejectPurchaseRequestCommand request, CancellationToken cancellationToken)
        {
            var pr = await _repository.GetByIdAsync(
                request.PurchaseRequestId,
                cancellationToken
            );

            if ( pr is null)
            {
                throw new Domain.Exceptions.InvalidOperationException(
                    "Reject PR",
                    "Purchase request not found"
                );
            }

            // Domain enforces rejection rules
            pr.Reject(request.Reason);

            await _repository.UpdateAsync(pr, cancellationToken);

        }
    }
}
