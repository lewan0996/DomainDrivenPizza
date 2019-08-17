using System.Threading.Tasks;
using Application.Menu.Commands;
using Application.Menu.Queries.DTO;
using AutoMapper;
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
        public async Task<ActionResult> Create([FromBody] IngredientDto ingredientDto)
        {
            var command = _mapper.Map<CreateIngredientCommand>(ingredientDto);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}