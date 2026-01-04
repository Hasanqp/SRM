using MediatR;

namespace PRService.Application.PurchaseRequests.Queries.GetPurchaseRequestById
{
    public sealed record GetPurchaseRequestByIdQuery(
        Guid PurchaseRequestId
    ) : IRequest<PurchaseRequestResult>;
}
