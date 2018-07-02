namespace WebApi.Core.Commands
{
    using MediatR;

    public class SimpleWithReturnCommand<T> : IRequest<T>
    {
        public string Id { get; }

        public SimpleWithReturnCommand(string id)
        {
            this.Id = id;
        }
    }
}