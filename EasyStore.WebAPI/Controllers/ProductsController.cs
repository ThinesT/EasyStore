using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyStore.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyStore.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class ProductsController : BaseController
    {
        public async Task<ActionResult<ProductListViewModel>> GetAllProducts()
        {
            var result = await Mediator.Send(new GetProductsListQuery());
            return Ok(new { data = result.Products });
        }
    }
}
