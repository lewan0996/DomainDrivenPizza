using System.Threading.Tasks;
using Delivery.Application.FinishDeliveryApplication;
using Delivery.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable 1591

namespace API.Contexts.Delivery
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DeliveryQueries _deliveryQueries;

        public DeliveryController(IMediator mediator, DeliveryQueries deliveryQueries)
        {
            _mediator = mediator;
            _deliveryQueries = deliveryQueries;
        }

        [HttpGet("orders/{supplierId:int}")]
        public async Task<IActionResult> GetSupplierOrders(int supplierId)
        {
            var supplierOrders = await _deliveryQueries.GetSupplierOrdersAsync(supplierId);

            return Ok(supplierOrders);
        }

        [HttpPatch("order/{orderId:int}/finish")]
        public async Task<IActionResult> FinishOrderDelivery(int orderId)
        {
            await _mediator.Send(new FinishDeliveryCommand(orderId));

            return NoContent();
        }
    }
}