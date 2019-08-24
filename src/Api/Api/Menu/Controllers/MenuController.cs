using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Queries;
using Application.Menu.Queries.DTO;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable 1591

namespace Api.Menu.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ProductQueries _productQueries;

        public MenuController(IMediator mediator, IMapper mapper, ProductQueries productQueries)
        {
            _mediator = mediator;
            _mapper = mapper;
            _productQueries = productQueries;
        }

        [HttpGet("Ingredients")]
        [ProducesResponseType(typeof(IReadOnlyList<IngredientDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllIngredients()
        {
            return Ok(await _productQueries.GetAllIngredientsAsync());
        }

        [HttpGet("Ingredients/{id}")]
        [ProducesResponseType(typeof(IngredientDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var ingredient = await _productQueries.GetIngredientByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        [HttpPost("Ingredients")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IngredientDto), (int)HttpStatusCode.Created)]
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

            return CreatedAtAction(nameof(Get), new {result.Id}, result);
        }
}
}