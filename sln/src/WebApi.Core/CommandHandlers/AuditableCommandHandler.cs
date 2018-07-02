namespace WebApi.Core.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using WebApi.Core.Commands;

    public class AuditableCommandHandler<T, U> : IRequestHandler<T, U>
        where T : IRequest<U> 
        where U : class
    {
        private readonly IRequestHandler<T, U> requestHandler;

        public AuditableCommandHandler(IRequestHandler<T, U> requestHandler)
        {
            this.requestHandler = requestHandler;
        }

        public async Task<U> Handle(T request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello!");            
            return await this.requestHandler.Handle(request, cancellationToken);
        }
    }
}