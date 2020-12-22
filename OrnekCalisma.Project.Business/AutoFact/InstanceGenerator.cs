using Autofac;

namespace OrnekCalisma.Project.Business.AutoFact
{
    public class InstanceGenerator
    {
        public static T GetInstance<T>()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<BusinessModule>();

            return containerBuilder.Build().Resolve<T>();
        }
    }
}
