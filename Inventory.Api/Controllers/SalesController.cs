using Inventory.Core.Application.Commands;
using Inventory.Core.Application.Queries;
using Inventory.Core.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Inventory.Api.Controllers
{
    [Route("api/v1/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [SwaggerOperation("Get Sales Data")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SalesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllSales()
        {
            var result = await _mediator.Send(new GetSalesQuery());
            if (result is not null)
            {
                return Ok(result);
            }

            return NotFound();

        }



        [HttpPost()]
        [SwaggerOperation("Add Sale")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSales([FromBody] CreateSaleRequest saleRequest)
        {
            var result = await _mediator.Send(new CreateSaleCommand { SaleRequest = saleRequest });

            return Created("/", result);

        }

    }
}
