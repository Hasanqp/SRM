using MediatR;
using PRService.Application.Abstractions.Persistence;

namespace PRService.Application.PurchaseRequests.Queries.GetPurchaseRequestById
{
    public sealed class GetPurchaseRequestByIdHandler : IRequestHandler<GetPurchaseRequestByIdQuery, PurchaseRequestResult>
    {
        private readonly IPurchaseRequestRepository _repository;

        public GetPurchaseRequestByIdHandler(IPurchaseRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<PurchaseRequestResult> Handle(GetPurchaseRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var pr = await _repository.GetByIdAsync(
                request.PurchaseRequestId,
                cancellationToken
            );

            if (pr is null)
            {
                throw new Domain.Exceptions.InvalidOperationException(
                    "Get PR",
                    "Purchase request not found"
                );
            }

            return new PurchaseRequestResult(
                pr.Id,
                pr.RequestNumber,
                pr.Description,
                pr.TotalAmount,
                pr.Status.ToString(),
                pr.CreatedDate
            );
        }
    }
}
