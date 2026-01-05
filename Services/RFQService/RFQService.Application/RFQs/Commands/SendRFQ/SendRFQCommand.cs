using MediatR;

namespace RFQService.Application.RFQs.Commands.SendRFQ
{
    public sealed record SendRFQCommand(
        Guid RFQId
    ) : IRequest;    
}
