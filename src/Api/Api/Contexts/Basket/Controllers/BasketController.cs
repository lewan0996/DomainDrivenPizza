using System.Threading.Tasks;
using API.Contexts.Basket.DTO;
using AutoMapper;
using Basket.Application.AddItemToBasketApplication;
using Basket.Application.CheckoutApplication;
using Basket.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Contexts.Basket.Controllers
{
    /// <summary>
    /// Contains basket related endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketQueries _basketQueries;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public BasketController(BasketQueries basketQueries, IMediator mediator, IMapper mapper)
        {
            _basketQueries = basketQueries;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets current user basket from browser cookie
        /// </summary>
        /// <returns>Current user's basket</returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var basketId = GetBasketId();

            if (basketId == null)
            {
                return NotFound();
            }

            var result = await _basketQueries.GetBasketAsync(basketId.Value);

            return Ok(result);
        }

        /// <summary>
        /// Adds an item to the current user's basket
        /// </summary>
        [HttpPost("Items")]
        public async Task<ActionResult> AddItemToBasket(AddItemToBasketDTO dto)
        {
            var basketId = GetBasketId();
            var command = _mapper.Map<AddItemToBasketCommand>(dto);
            command.BasketId = basketId;

            var basketDto = await _mediator.Send(command);

            if (basketId == null)
            {
                CreateBasketCookie(basketDto.Id);
            }

            return CreatedAtAction(nameof(Get), basketDto);
        }

        /// <summary>
        /// Creates a new order based on customer's basket
        /// </summary>
        /// <param name="dto">Checkout data</param>
        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout(CheckoutDTO dto)
        {
            var basketId = GetBasketId();

            if (basketId == null)
            {
                return BadRequest();
            }

            var checkoutCommand = _mapper.Map<CheckoutCommand>(dto);
            checkoutCommand.BasketId = basketId.Value;

            await _mediator.Send(checkoutCommand); //todo it should somehow return orderId

            return NoContent();
        }

        private int? GetBasketId()
        {
            var stringValueFromCookie = Request.Cookies["BasketId"];
            if (stringValueFromCookie == null)
            {
                return null;
            }

            return int.Parse(stringValueFromCookie);
        }

        private void CreateBasketCookie(int basketId)
        {
            Response.Cookies.Append("BasketId", basketId.ToString());
        }
    }
}