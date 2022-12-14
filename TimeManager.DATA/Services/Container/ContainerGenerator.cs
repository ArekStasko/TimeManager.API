using Autofac;
using System.Reflection;

namespace TimeManager.DATA.Services.ContainerGenerator
{
    public class ContainerFactory
    {

        public static IContainer CreateProcessorsContainer()
        {
            var container = new ContainerBuilder();
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "TimeManager.DATA.Processors.TaskProcessor");

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.DATA.Processors.TaskProcessor" || t.Namespace == "TimeManager.DATA.Processors.TaskSetProcessor")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
                 
            return container.Build();
        }

    }
}
