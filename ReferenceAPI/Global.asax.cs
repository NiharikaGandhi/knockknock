using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ReferenceAPI.Services;
using ReferenceAPI.Setting;

//my demo

namespace ReferenceAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterType<MathService>().As<IMathService>();
            builder.RegisterType<StringService>().As<IStringService>();
            builder.RegisterType<ShapeService>().As<IShapeService>();
            builder.RegisterType<TokenSettings>().As<ITokenSettings>();
            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
