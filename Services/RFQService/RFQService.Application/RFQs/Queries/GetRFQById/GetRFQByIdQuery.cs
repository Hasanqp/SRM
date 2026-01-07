using MediatR;

namespace RFQService.Application.RFQs.Queries.GetRFQById
{
    public sealed record GetRFQByIdQuery(
        Guid RFQId
        ) : IRequest<RFQSummaryResult>;    
}
