using MediatR;
using PRService.Application.Abstractions.Persistence;

namespace PRService.Application.PurchaseRequests.Queries.GetPurchaseRequests
{
    public sealed class GetPurchaseRequestsHandler : IRequestHandler<GetPurchaseRequestsQuery, IReadOnlyList<PurchaseRequestResult>>
    {
        private readonly IPurchaseRequestRepository _repository;

        public GetPurchaseRequestsHandler(IPurchaseRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<PurchaseRequestResult>> Handle(GetPurchaseRequestsQuery request, CancellationToken cancellationToken)
        {
            var prs = await _repository.GetAllAsync(cancellationToken);
                return prs
                .Select(pr => new PurchaseRequestResult(
                    pr.Id,
                    pr.RequestNumber,
                    pr.Description,
                    pr.TotalAmount,
                    pr.Status.ToString(),
                    pr.CreatedDate
                ))
                .ToList();
        }
    }
}
