using Autofac;
using OrnekCalisma.Core;
using OrnekCalisma.Project.Business.Abstract;
using OrnekCalisma.Project.Business.Concrete;

namespace OrnekCalisma.Project.Business.AutoFact
{
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MusteriManager>().As<IMusteriService>().InstancePerDependency();
            builder.RegisterType<SepetManager>().As<ISepetService>().InstancePerDependency();
            builder.RegisterType<SepetUrunManager>().As<ISepetUrunService>().InstancePerDependency();
            builder.RegisterType<DbOrnekConnection>().As<IDbOrnekConnection>().InstancePerDependency();
        }
    }
}
