using MediatR;
using Microsoft.AspNetCore.Mvc;
using RFQService.API.Contracts.Bids;
using RFQService.API.Contracts.RFQs;
using RFQService.Application.RFQs.Commands.AwardRFQ;
using RFQService.Application.RFQs.Commands.CancelRFQ;
using RFQService.Application.RFQs.Commands.CloseRFQ;
using RFQService.Application.RFQs.Commands.CreateRFQ;
using RFQService.Application.RFQs.Commands.SendRFQ;
using RFQService.Application.RFQs.Commands.SubmitBid;
using RFQService.Application.RFQs.Queries.GetRFQById;

namespace RFQService.API.Controllers
{
    [ApiController]
    [Route("api/rfqs")]
    public class RFQsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RFQsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRFQRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new CreateRFQCommand(
                    request.PurchaseRequestId,
                    request.Title),
                cancellationToken);

            return CreatedAtAction(
                nameof(Create),
                new { id = result.Id },
                result);
        }

        [HttpPost("{id:guid}/send")]
        public async Task<IActionResult> SendToVendors(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new SendRFQCommand(id),
                cancellationToken);

            return NoContent();
        }

        [HttpPost("{id:guid}/close")]
        public async Task<IActionResult> Close(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new CloseRFQCommand(id),
                cancellationToken);

            return NoContent();
        }

        [HttpPost("{id:guid}/cancel")]
        public async Task<IActionResult> Cancel(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new CancelRFQCommand(id),
                cancellationToken);

            return NoContent();
        }

        [HttpPost("{id:guid}/bids")]
        public async Task<IActionResult> SubmitBid(Guid id, [FromBody] SubmitBidRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new SubmitBidCommand(
                    id,
                    request.SupplierId,
                    request.Amount),
                cancellationToken);

            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetRFQByIdQuery(id),
                cancellationToken);

            return Ok(result);
        }

        [HttpPost("{id:guid}/award")]
        public async Task<IActionResult> Award(Guid id, [FromBody] AwardRFQRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new AwardRFQCommand(
                    id,
                    request.BidId),
                cancellationToken);

            return NoContent();
        }

    }
}
