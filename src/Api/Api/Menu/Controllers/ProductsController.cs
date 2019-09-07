using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Menu.DTO.ProductDTO;
using Application.Menu.Commands.ProductCommands;
using Application.Menu.Exceptions;
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
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ProductQueries _productQueries;

        public ProductsController(IMediator mediator, IMapper mapper, ProductQueries productQueries)
        {
            _mediator = mediator;
            _mapper = mapper;
            _productQueries = productQueries;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<ProductDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _productQueries.GetAllProductsAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _productQueries.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProductDTO), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> Create([FromBody] CreateProductDTO ingredientDto)
        {
            var command = _mapper.Map<CreateProductCommand>(ingredientDto);

            ProductDTO result;
            try
            {
                result = await _mediator.Send(command);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Errors);
            }

            return CreatedAtAction(nameof(Get), new { result.Id }, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);

            try
            {
                await _mediator.Send(command);
            }
            catch (RecordNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Update(int id, UpdateProductDTO dto)
        {
            var command = _mapper.Map<UpdateProductCommand>(dto);
            command.Id = id;

            try
            {
                await _mediator.Send(command);
            }
            catch (RecordNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}