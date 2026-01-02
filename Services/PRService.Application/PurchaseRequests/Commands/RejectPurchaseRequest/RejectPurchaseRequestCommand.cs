using MediatR;

namespace PRService.Application.PurchaseRequests.Commands.RejectPurchaseRequest
{
    public sealed record RejectPurchaseRequestCommand(

    Guid PurchaseRequestId,
        string Reason
    ) : IRequest;
}
