using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Monkeylab.Templates.Application.Commons.Behaviours
{
    public class AuditBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public AuditBehaviour()
        {

        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return await next();
        }
    }
}