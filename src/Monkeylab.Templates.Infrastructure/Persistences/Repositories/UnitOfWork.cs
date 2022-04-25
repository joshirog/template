using System.Threading.Tasks;
using Monkeylab.Templates.Application.Commons.Interfaces;
using Monkeylab.Templates.Infrastructure.Persistences.Contexts;

namespace Monkeylab.Templates.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public ICustomerRepository Customers => new CustomerRepository(_context);
        
        public async Task<bool> Commit() => await _context.SaveChangesAsync() > 0;

        public async Task Rollback()
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        { 
            _context.Dispose();
        }
    }
}