using System;
using Microsoft.AspNetCore.Mvc;
using Monkeylab.Templates.Domain.Entities;

namespace Monkeylab.Templates.Api.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    public class CustomerController : ApiControllerBase
    {
        /// <summary>
        /// Get a list with all items.
        /// </summary>
        /// <response code="200">Returns a list with the available sample responses.</response>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Customer one",
                CreatedAt = DateTime.Now
            });
        }
    }
}