using MediatR;

namespace RFQService.Application.RFQs.Commands.CreateRFQ
{
    public sealed record CreateRFQCommand(
        Guid PurchaseRequestId,
        string Title
    ) : IRequest<CreateRFQResult>;
}
