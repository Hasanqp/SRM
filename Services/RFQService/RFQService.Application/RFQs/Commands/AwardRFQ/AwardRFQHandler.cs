using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Exceptions;

namespace RFQService.Application.RFQs.Commands.AwardRFQ
{
    public sealed class AwardRFQHandler : IRequestHandler<AwardRFQCommand>
    {
        private readonly IRFQRepository _repository;

        public AwardRFQHandler(IRFQRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(AwardRFQCommand request, CancellationToken cancellationToken)
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

            rfq.Award(request.BidId);

            await _repository.UpdateAsync(rfq, cancellationToken);
        }
    }
}
