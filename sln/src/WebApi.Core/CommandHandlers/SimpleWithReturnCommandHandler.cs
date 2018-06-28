namespace WebApi.Core.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using WebApi.Core.Commands;
    using WebApi.Core.Responses;

    public class SimpleWithReturnCommandHandler : IRequestHandler<SimpleWithReturnCommand<SimpleWithReturnResponse>, SimpleWithReturnResponse>
    {
        public Task<SimpleWithReturnResponse> Handle(SimpleWithReturnCommand<SimpleWithReturnResponse> request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new SimpleWithReturnResponse("result"));
        }
    }
}