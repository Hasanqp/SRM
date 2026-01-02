using MediatR;

namespace PRService.Application.PurchaseRequests.Commands.SubmitPurchaseRequest
{
    public sealed record SubmitPurchaseRequestCommand(
        Guid PurchaseRequestId
    ) : IRequest;
}
