using MediatR;
using Microsoft.AspNetCore.Mvc;
using PRService.API.Contracts.Common;
using PRService.API.Contracts.PurchaseRequests;
using PRService.Application.PurchaseRequests.Commands.ApprovePurchaseRequest;
using PRService.Application.PurchaseRequests.Commands.CreatePurchaseRequest;
using PRService.Application.PurchaseRequests.Commands.RejectPurchaseRequest;
using PRService.Application.PurchaseRequests.Commands.SubmitPurchaseRequest;
using PRService.Application.PurchaseRequests.Queries.GetPurchaseRequestById;
using PRService.Application.PurchaseRequests.Queries.GetPurchaseRequests;

namespace PRService.API.Controllers
{
    [ApiController]
    [Route("api/purchase-requests")]
    public class PurchaseRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PurchaseRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseRequestRequest request, CancellationToken cancellationToken)
        {
            var command = new CreatePurchaseRequestCommand(
                request.RequestNumber,
                request.Description,
                request.TotalAmount
            );

            var result = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction (
                nameof(Create),
                new { id = result.Id },
                result);
        }

        [HttpPost("{id:guid}/submit")]
        public async Task<IActionResult> Submit(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new SubmitPurchaseRequestCommand(id),
                cancellationToken);

            return NoContent();
        }

        [HttpPost("{id:guid}/reject")]
        public async Task<IActionResult> Reject(Guid id, [FromBody] RejectRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new RejectPurchaseRequestCommand(id, request.Reason),
                cancellationToken);

            return NoContent();
        }

        [HttpPost("{id:guid}/approve")]
        public async Task<IActionResult> Approve(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new ApprovePurchaseRequestCommand(id),
                cancellationToken);

            return NoContent();
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetPurchaseRequestByIdQuery(id),
                cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetPurchaseRequestsQuery(),
                cancellationToken);

            return Ok(result);
        }
    }
}
