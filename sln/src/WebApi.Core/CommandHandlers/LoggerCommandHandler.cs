namespace WebApi.Core.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Serilog;

    public class LoggerCommandHandler<T, U> : IRequestHandler<T, U>
        where T : IRequest<U>
    {
        private readonly IRequestHandler<T, U> requestHandler;

        public LoggerCommandHandler(IRequestHandler<T, U> requestHandler)
        {
            this.requestHandler = requestHandler;
        }

        public async Task<U> Handle(T request, CancellationToken cancellationToken)
        {
            Log.Logger.Information("LoggerCommandHandler");            
            return await this.requestHandler.Handle(request, cancellationToken);
        }
    }
}