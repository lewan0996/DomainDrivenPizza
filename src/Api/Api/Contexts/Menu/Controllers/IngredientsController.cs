using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.Contexts.Menu.DTO.IngredientDTO;
using AutoMapper;
using MediatR;
using Menu.Application.IngredientApplications.CreateIngredientApplication;
using Menu.Application.IngredientApplications.DeleteIngredientApplication;
using Menu.Application.IngredientApplications.UpdateIngredientApplication;
using Menu.Application.Queries;
using Menu.Application.Queries.DTO;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable 1591

namespace API.Contexts.Menu.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ProductQueries _productQueries;

        public IngredientsController(IMediator mediator, IMapper mapper, ProductQueries productQueries)
        {
            _mediator = mediator;
            _mapper = mapper;
            _productQueries = productQueries;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<IngredientDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _productQueries.GetAllIngredientsAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IngredientDTO), (int)HttpStatusCode.OK)]
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

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IngredientDTO), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> Create([FromBody] CreateIngredientDTO ingredientDto)
        {
            var command = _mapper.Map<CreateIngredientCommand>(ingredientDto);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { result.Id }, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteIngredientCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Update(int id, [FromBody]UpdateIngredientDTO dto)
        {
            var command = _mapper.Map<UpdateIngredientCommand>(dto);
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }
    }
}