using System;
using System.Threading.Tasks;

namespace Monkeylab.Templates.Application.Commons.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }

        Task<bool> Commit();

        Task Rollback();
    }
}