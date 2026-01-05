using MediatR;

namespace RFQService.Application.RFQs.Commands.AwardRFQ
{
    public sealed record AwardRFQCommand(
        Guid RFQId,
        Guid BidId
    ) : IRequest;
}
