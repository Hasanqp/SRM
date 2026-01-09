using MediatR;

namespace PRService.Application.PurchaseRequests.Commands.ApprovePurchaseRequest
{
    public sealed record ApprovePurchaseRequestCommand(
        Guid PurchaseRequestId
    ) : IRequest;
}
