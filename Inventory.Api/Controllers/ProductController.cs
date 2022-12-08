using Inventory.Core.Application.Commands;
using Inventory.Core.Application.Queries;
using Inventory.Core.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventory.Api.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation("Get Products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            if (result is not null)
            {
                return Ok(result);
            }

            return NotFound();

        }



        [HttpPost()]
        [SwaggerOperation("Add Product")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest createProductRequest)
        {
            var result = await _mediator.Send(new CreateProductComand { ProductRequest = createProductRequest });

            return Created("/", result);

        }
    }
}
