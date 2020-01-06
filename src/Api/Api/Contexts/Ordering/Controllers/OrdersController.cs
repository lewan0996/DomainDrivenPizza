using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Queries;
using Ordering.Application.ShipOrderApplication;

#pragma warning disable 1591

namespace API.Contexts.Ordering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderingQueries _orderingQueries;
        private readonly IMediator _mediator;

        public OrdersController(OrderingQueries orderingQueries, IMediator mediator)
        {
            _orderingQueries = orderingQueries;
            _mediator = mediator;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetOrdersByEmail(string email)
        {
            var orders = await _orderingQueries.GetOrdersByUserEmail(email);

            if (!orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpPost("ship/{id}")]
        public async Task<IActionResult> ShipOrder(int id)
        {
            var shipOrderCommand = new ShipOrderCommand(id);
            await _mediator.Send(shipOrderCommand);

            return NoContent();
        }
    }
}