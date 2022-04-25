using MediatR;
using Monkeylab.Templates.Application.Commons.Dtos;

namespace Monkeylab.Templates.Application.Services.Customers.Queries.ReportCustomer
{
    public class ReportCustomerQuery : IRequest<BaseResponse<BaseResponsePaginate<ReportCustomerResponse>>>
    {
        public BaseRequestPaginate Paginate { get; set; }

        public string Name { get; set; }
    }
}