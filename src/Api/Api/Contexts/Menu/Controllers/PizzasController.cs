using API.Contexts.Menu.DTO.PizzaDTO;
using AutoMapper;
using MediatR;
using Menu.Application.PizzaApplications.CreatePizzaApplication;
using Menu.Application.PizzaApplications.DeletePizzaApplication;
using Menu.Application.PizzaApplications.UpdatePizzaApplication;
using Menu.Application.Queries;
using Menu.Application.Queries.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace API.Contexts.Menu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ProductQueries _productQueries;

        public PizzasController(IMediator mediator, IMapper mapper, ProductQueries productQueries)
        {
            _mediator = mediator;
            _mapper = mapper;
            _productQueries = productQueries;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<PizzaDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _productQueries.GetAllPizzasAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PizzaDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var pizza = await _productQueries.GetPizzaByIdAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(PizzaDTO), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> Create([FromBody] CreatePizzaDTO pizzaDto)
        {
            var command = _mapper.Map<CreatePizzaCommand>(pizzaDto);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { result.Id }, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePizzaCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Update(int id, UpdatePizzaDTO dto)
        {
            var command = _mapper.Map<UpdatePizzaCommand>(dto);
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }
    }
}