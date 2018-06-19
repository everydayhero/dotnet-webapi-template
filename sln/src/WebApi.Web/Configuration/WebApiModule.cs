namespace WebApi.Web.Configuration
{
    using Autofac;
    using WebApi.Core.Configuration;

    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new WebApiCoreModule());
        }
    }
}