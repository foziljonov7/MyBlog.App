using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponce> : IPipelineBehavior<TRequest, TResponce> where TRequest : IRequest<TResponce>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponce>> logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponce>> logger)
        {
            this.logger = logger;
        }
        public async Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogDebug($"{typeof(TRequest).Name}Request before execution");
                return await next();
            }
            finally
            {
                logger.LogDebug($"{typeof(TRequest).Name} after execution");
            }
        }
    }
}
