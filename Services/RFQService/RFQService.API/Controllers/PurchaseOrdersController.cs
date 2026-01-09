using MediatR;
using Microsoft.AspNetCore.Mvc;
using RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrders;
using RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrdersByRFQId;

namespace RFQService.API.Controllers
{
    [ApiController]
    [Route("api/purchase-orders")]
    public sealed class PurchaseOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetPurchaseOrdersQuery(),
                cancellationToken);

            return Ok(result);
        }

        [HttpGet("by-rfq/{rfqId:guid}")]
        public async Task<IActionResult> GetByRFQId(Guid rfqId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetPurchaseOrdersByRFQIdQuery(rfqId),
                cancellationToken);

            return Ok(result);
        }
    }
}
