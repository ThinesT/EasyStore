using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyStore.Application.Products.Commands.CreateProduct;
using EasyStore.Application.Products.Queries.GetProduct;
using EasyStore.Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyStore.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiVersion("1.0")]
    public class ProductsController : BaseController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await Mediator.Send(new GetProductsListQuery());
            return Ok(new { data = result.Products });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await Mediator.Send(new GetProductQuery { Id = id });

            return Ok(new { data = product });
        }
    }
}
