using System.Threading.Tasks;
using Api.Basket.DTO;
using Application.Basket.Commands;
using Application.Basket.Queries;
using Application.Basket.Queries.DTO;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketQueries _basketQueries;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BasketController(BasketQueries basketQueries, IMediator mediator, IMapper mapper)
        {
            _basketQueries = basketQueries;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var basketId = GetBasketId();

            if (basketId == null)
            {
                return NotFound();
            }

            var result = await _basketQueries.GetBasketAsync(basketId.Value);

            return Ok(_mapper.Map<BasketDTO>(result));
        }

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