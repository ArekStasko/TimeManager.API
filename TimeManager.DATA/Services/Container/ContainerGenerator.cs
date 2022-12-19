using Autofac;
using System.Reflection;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Services.ContainerGenerator
{
    public class ContainerFactory
    {

        public static IContainer CreateProcessorsContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.DATA.Processors.TaskProcessor" || t.Namespace == "TimeManager.DATA.Processors.TaskSetProcessor")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
                 
            return container.Build();
        }

    }
}
