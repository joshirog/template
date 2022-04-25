using Microsoft.EntityFrameworkCore;
using Monkeylab.Templates.Application.Commons.Interfaces;
using Monkeylab.Templates.Domain.Entities;

namespace Monkeylab.Templates.Infrastructure.Persistences.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
            
        }
    }
}