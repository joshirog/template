using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monkeylab.Templates.Application.Commons.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            var responseName = typeof(TResponse).Name;
            
            try
            {
                _logger.LogInformation("Request: {Name} {@Request}", requestName, request);
                
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception for Request {Name} {@Request}", requestName, request);

                throw;
            }
            finally
            {
                _logger.LogInformation("Finally: {RequestName} {@Request} {ResposeName}", requestName, request, responseName);
            }
        }
    }
}