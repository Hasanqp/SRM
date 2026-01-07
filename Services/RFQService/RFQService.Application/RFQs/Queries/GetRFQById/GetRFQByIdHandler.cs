using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Exceptions;

namespace RFQService.Application.RFQs.Queries.GetRFQById
{
    public sealed class GetRFQByIdHandler : IRequestHandler<GetRFQByIdQuery, RFQSummaryResult>
    {
        private readonly IRFQRepository _repository;

        public GetRFQByIdHandler(IRFQRepository repository)
        {
            _repository = repository;
        }
        public async Task<RFQSummaryResult> Handle(GetRFQByIdQuery request, CancellationToken cancellationToken)
        {
            var rfq = await _repository.GetByIdAsync(
                request.RFQId,
                cancellationToken
            );

            if (rfq is null)
            {
                throw new NotFoundException(
                    "RFQ",
                    request.RFQId
                );
            }

            var bids = rfq.Bids
                .Select(b => new BidResult(
                    b.Id,
                    b.SupplierId,
                    b.Amount,
                    b.SubmittedDate))
                .ToList();

            return new RFQSummaryResult(
                rfq.Id,
                rfq.PurchaseRequestId,
                rfq.Title,
                rfq.Status.ToString(),
                rfq.CreatedDate,
                bids
            );
        }
    }
}
