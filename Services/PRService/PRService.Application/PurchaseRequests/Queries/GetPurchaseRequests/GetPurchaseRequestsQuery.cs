using MediatR;

namespace PRService.Application.PurchaseRequests.Queries.GetPurchaseRequests
{
    public sealed record GetPurchaseRequestsQuery(
    ) : IRequest<IReadOnlyList<PurchaseRequestResult>>;
}
