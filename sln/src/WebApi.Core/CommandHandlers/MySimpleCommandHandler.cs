namespace WebApi.Core.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Serilog;
    using WebApi.Core.Commands;

    public class MySimpleCommandHandler : IRequestHandler<MySimpleCommand, Unit>
    {
        public Task<Unit> Handle(MySimpleCommand request, CancellationToken cancellationToken)
        {
            Log.Logger.Information("MySimpleCommandHandler");  

            return Unit.Task;
        }
    }
}