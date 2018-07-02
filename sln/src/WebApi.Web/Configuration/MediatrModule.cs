namespace WebApi.Web.Configuration
{
    using Autofac;
    using MediatR;
    using WebApi.Core.CommandHandlers;
    using WebApi.Core.Commands;
    using WebApi.Core.Responses;

    public class MediatrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleWithReturnCommandHandler>()
                .Named<IRequestHandler<SimpleWithReturnCommand<SimpleWithReturnResponse>, SimpleWithReturnResponse>>("handler")
                .InstancePerDependency();

            builder.RegisterDecorator<IRequestHandler<SimpleWithReturnCommand<SimpleWithReturnResponse>, SimpleWithReturnResponse>>(
                (ctx, inner) => new LoggerCommandHandler<SimpleWithReturnCommand<SimpleWithReturnResponse>, SimpleWithReturnResponse>(new AuditableCommandHandler<SimpleWithReturnCommand<SimpleWithReturnResponse>, SimpleWithReturnResponse>(inner)),
                "handler"
            );
        }
    }
}