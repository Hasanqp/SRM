using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Exceptions;

namespace RFQService.Application.RFQs.Commands.SendRFQ
{
    public sealed class SendRFQHandler : IRequestHandler<SendRFQCommand>
    {
        private readonly IRFQRepository _repository;

        public SendRFQHandler(IRFQRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(SendRFQCommand request, CancellationToken cancellationToken)
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
            rfq.SendToVendors();

            await _repository.UpdateAsync(rfq, cancellationToken);
        }
    }
}
