using MediatR;

namespace RFQService.Application.RFQs.Commands.CancelRFQ
{
    public sealed record CancelRFQCommand(
        Guid RFQId
    ) : IRequest;
}
