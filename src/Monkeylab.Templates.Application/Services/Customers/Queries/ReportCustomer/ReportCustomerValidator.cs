using FluentValidation;

namespace Monkeylab.Templates.Application.Services.Customers.Queries.ReportCustomer
{
    public class ReportCustomerValidator : AbstractValidator<ReportCustomerQuery>
    {
        public ReportCustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}