using MediatR;
using Microsoft.AspNetCore.Mvc;
using RFQService.API.Contracts.RFQs;
using RFQService.Application.RFQs.Commands.CloseRFQ;
using RFQService.Application.RFQs.Commands.CreateRFQ;
using RFQService.Application.RFQs.Commands.SendRFQ;

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

    }
}
