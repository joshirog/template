using AutoMapper;
using Monkeylab.Templates.Domain.Entities;

namespace Monkeylab.Templates.Application.Services.Customers.Queries.ReportCustomer
{
    public class ReportCustomerMapper : Profile
    {
        public ReportCustomerMapper()
        {
            CreateMap<Customer, ReportCustomerResponse>();
        }
    }
}