using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyStore.Application.Customers.Commands.CreateCustomer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyStore.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiVersion("1.0")]
    public class CustomersController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateCustomer([FromBody]CreateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
