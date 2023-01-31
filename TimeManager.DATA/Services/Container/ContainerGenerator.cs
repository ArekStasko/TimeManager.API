using Autofac;
using System.Reflection;
using AutoMapper;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Controllers.TaskSetControllers;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Services.ContainerGenerator
{
    public class ContainerFactory
    {

        public static IContainer CreateProcessorsContainer(DataContext _context, ILogger<TaskController> _taskLogger, ILogger<TaskSetController> _taskSetLogger, IMQManager _mqManager, IMapper _mapper)
        {

            var container = new ContainerBuilder();

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.DATA.Processors.TaskProcessor")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .WithParameter(new TypedParameter(typeof(DataContext), _context))
                .WithParameter(new TypedParameter(typeof(ILogger<TaskController>), _taskLogger))
                .WithParameter(new TypedParameter(typeof(IMQManager), _mqManager))
                .WithParameter(new TypedParameter(typeof(IMapper), _mapper));

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.DATA.Processors.TaskSetProcessor")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .WithParameter(new TypedParameter(typeof(DataContext), _context))
                .WithParameter(new TypedParameter(typeof(ILogger<TaskSetController>), _taskSetLogger))
                .WithParameter(new TypedParameter(typeof(IMQManager), _mqManager));


            return container.Build();
        }

    }
}
