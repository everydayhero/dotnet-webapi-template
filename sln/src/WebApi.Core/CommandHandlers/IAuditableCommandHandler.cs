namespace WebApi.Core.CommandHandlers
{
    public interface IAuditableCommandHandler<in TRequest>
    {
         void Audit(TRequest request);
    }
}