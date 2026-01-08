using MediatR;
using Microsoft.AspNetCore.Mvc;
using RFQService.Application.PurchaseOrders.Queries.GetPurchaseOrders;

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
    }
}
