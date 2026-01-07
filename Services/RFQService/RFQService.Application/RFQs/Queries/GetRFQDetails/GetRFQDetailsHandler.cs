using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Exceptions;

namespace RFQService.Application.RFQs.Queries.GetRFQDetails
{
    public sealed class GetRFQDetailsHandler : IRequestHandler<GetRFQDetailsQuery, RFQDetailsResult>
    {
        private readonly IRFQRepository _repository;

        public GetRFQDetailsHandler(IRFQRepository repository)
        {
            _repository = repository;
        }

        public async Task<RFQDetailsResult> Handle(GetRFQDetailsQuery request, CancellationToken cancellationToken)
        {
            var rfq = await _repository.GetByIdAsync(request.RFQId, cancellationToken);

            if (rfq is null)
            {
                throw new NotFoundException("RFQ", request.RFQId);
            }

            return new RFQDetailsResult(
                rfq.Id,
                rfq.PurchaseRequestId,
                rfq.Title,
                rfq.Status.ToString(),
                rfq.CreatedDate,
                rfq.WinningBidId,
                rfq.Bids.Select(b =>
                    new BidResult(
                        b.Id,
                        b.SupplierId,
                        b.Amount))
                .ToList()
            );
        }
    }
}
