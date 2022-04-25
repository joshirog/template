using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monkeylab.Templates.Application.Commons.Dtos;
using Monkeylab.Templates.Application.Services.Customers.Queries.ReportCustomer;

namespace Monkeylab.Templates.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    public class CustomerController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromHeader] BaseAudit audit, [FromQuery] ReportCustomerQuery request) 
            => Ok(await Mediator.Send(request));
    }
}