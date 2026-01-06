using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Common;

namespace RFQService.Application.RFQs.Commands.CreateRFQ
{
    public sealed class CreateRFQHandler : IRequestHandler<CreateRFQCommand, CreateRFQResult>
    {
        private readonly IRFQRepository _repository;

        public CreateRFQHandler(IRFQRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateRFQResult> Handle(CreateRFQCommand request, CancellationToken cancellationToken)
        {
            var rfq = RFQ.Create(
                request.PurchaseRequestId,
                request.Title
            );

            await _repository.AddAsync(rfq, cancellationToken);

            return new CreateRFQResult(
                rfq.Id,
                rfq.PurchaseRequestId,
                rfq.Status.ToString(),
                rfq.CreatedDate
            );
        }
    }
}
