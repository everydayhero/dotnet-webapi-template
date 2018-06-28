namespace WebApi.Web.Configuration
{
    using Autofac;
    using WebApi.Core.CommandHandlers;
    using WebApi.Core.Commands;
    using WebApi.Core.Responses;

    public class MediatrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleWithReturnCommandHandler>().AsImplementedInterfaces().InstancePerDependency();
        }
    }
}