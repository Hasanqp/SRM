using MediatR;

namespace RFQService.Application.RFQs.Queries.GetRFQDetails
{
    public sealed record GetRFQDetailsQuery(
        Guid RFQId
    ) : IRequest<RFQDetailsResult>;
}
