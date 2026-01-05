using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Exceptions;

namespace RFQService.Application.RFQs.Commands.CloseRFQ
{
    public sealed class CloseRFQHandler : IRequestHandler<CloseRFQCommand>
    {
        private readonly IRFQRepository _repository;
        public CloseRFQHandler(IRFQRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CloseRFQCommand request, CancellationToken cancellationToken)
        {
            var rfq = await _repository.GetByIdAsync(
                request.RFQId,
                cancellationToken);

            if (rfq is null)
            {
                throw new NotFoundException(
                    "RFQ",
                    request.RFQId
                );
            }

            // Domain rule
            rfq.Close();

            await _repository.UpdateAsync(rfq, cancellationToken);
        }
    }
}
