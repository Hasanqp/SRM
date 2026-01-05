using MediatR;

namespace RFQService.Application.RFQs.Commands.SubmitBid
{
    public sealed record SubmitBidCommand(
        Guid RFQId,
        Guid SupplierId,
        decimal Amount
    ) : IRequest;
}
