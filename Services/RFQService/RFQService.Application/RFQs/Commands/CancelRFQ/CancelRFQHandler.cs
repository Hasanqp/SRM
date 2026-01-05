using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Exceptions;

namespace RFQService.Application.RFQs.Commands.CancelRFQ
{
    public sealed class CancelRFQHandler : IRequestHandler<CancelRFQCommand>
    {
        private readonly IRFQRepository _repository;

        public CancelRFQHandler(IRFQRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(CancelRFQCommand request, CancellationToken cancellationToken)
        {
            var rfq = await _repository.GetByIdAsync(
                request.RFQId,
                cancellationToken);

            if (rfq is null)
            {
                throw new NotFoundException(
                    "RFQ",
                    request.RFQId);
            }

            // Domain rule
            rfq.Cancel();

            await _repository.UpdateAsync(rfq, cancellationToken);
        }
    }
}
