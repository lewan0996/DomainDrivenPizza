using System.Net;
using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Menu.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MenuController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Ingredients")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Ingredient), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> Create([FromBody] IngredientDto ingredientDto)
        {
            var command = _mapper.Map<CreateIngredientCommand>(ingredientDto);

            IngredientDto result;
            try
            {
                result = await _mediator.Send(command);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Errors);
            }

            return Ok(result);
        }
    }
}