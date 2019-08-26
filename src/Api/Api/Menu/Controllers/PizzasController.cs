﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Menu.DTO;
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

            PizzaDTO result;
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
    }
}