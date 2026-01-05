using MediatR;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQService.Application.RFQs.Commands.SubmitBid
{
    public sealed class SubmitBidHandler : IRequestHandler<SubmitBidCommand>
    {
        private readonly IRFQRepository _repository;

        public SubmitBidHandler(IRFQRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(SubmitBidCommand request, CancellationToken cancellationToken)
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
            rfq.SubmitBid(
                request.SupplierId,
                request.Amount);

            await _repository.UpdateAsync(rfq, cancellationToken);
        }

    }
}
