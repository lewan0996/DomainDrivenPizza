using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Queries;

namespace API.Contexts.Ordering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderingQueries _orderingQueries;

        public OrdersController(OrderingQueries orderingQueries)
        {
            _orderingQueries = orderingQueries;
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
    }
}