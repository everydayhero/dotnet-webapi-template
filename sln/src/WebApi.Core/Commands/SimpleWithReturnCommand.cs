namespace WebApi.Core.Commands
{
    using MediatR;

    public class SimpleWithReturnCommand<T> : IRequest<T>
    {

    }
}