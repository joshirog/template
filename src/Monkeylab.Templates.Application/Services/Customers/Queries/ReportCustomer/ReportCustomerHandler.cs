using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Monkeylab.Templates.Application.Commons.Dtos;
using Monkeylab.Templates.Application.Commons.Interfaces;

namespace Monkeylab.Templates.Application.Services.Customers.Queries.ReportCustomer
{
    public class ReportCustomerHandler : IRequestHandler<ReportCustomerQuery, BaseResponse<BaseResponsePaginate<ReportCustomerResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<ReportCustomerHandler> _logger;


        public ReportCustomerHandler(IUnitOfWork uow, ILogger<ReportCustomerHandler> logger, IMapper mapper)
        {
            _uow = uow;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BaseResponsePaginate<ReportCustomerResponse>>> Handle(ReportCustomerQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Test logger ....");
            
            return BaseResponse.Ok("ok", _mapper.Map<BaseResponsePaginate<ReportCustomerResponse>>(await _uow.Customers.GetPaginate(request.Paginate.PageNumber, request.Paginate.PageSize)));
        }
    }
}
