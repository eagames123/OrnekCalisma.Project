using Autofac;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OrnekCalisma.Project.Business.Abstract;
using OrnekCalisma.Project.Business.Concrete;
using Autofac.Integration.Mvc;
using OrnekCalisma.Core;

namespace OrnekCalisma.Project.WEB.UI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<MusteriManager>().As<IMusteriService>().InstancePerDependency();
            builder.RegisterType<SepetManager>().As<ISepetService>().InstancePerDependency();
            builder.RegisterType<SepetUrunManager>().As<ISepetUrunService>().InstancePerDependency();
            builder.RegisterType<DbOrnekConnection>().As<IDbOrnekConnection>().InstancePerDependency();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
