namespace WebApi.Core.Configuration
{
    using Autofac;

    public class WebApiCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register everything that ends in 'Service' to it's implemented interfaces
            builder.RegisterAssemblyTypes(typeof(WebApiCoreModule).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}