using System;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace EasyStore.Application.Infrastructure
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IAppLogger<TRequest> _logger;

        public RequestLogger(IAppLogger<TRequest> logger)
        {
            _logger = logger;
        }
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("EasyStore Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}
