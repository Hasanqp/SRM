using MediatR;

namespace RFQService.Application.RFQs.Commands.CloseRFQ
{
    public sealed record CloseRFQCommand(
        Guid RFQId
    ) : IRequest;
}
