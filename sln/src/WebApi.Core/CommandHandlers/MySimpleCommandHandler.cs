namespace WebApi.Core.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using WebApi.Core.Commands;

    public class MySimpleCommandHandler : IRequestHandler<MySimpleCommand>
    {
        public Task<Unit> Handle(MySimpleCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}