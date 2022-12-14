using TimeManager.DATA.Services.ContainerGenerator;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using TimeManager.DATA.Processors.TaskSetProcessor;
using Autofac;

namespace TimeManager.DATA.Services.Container
{
    public class Processors : IProcessors
    {
        private IContainer _container { get; } = ContainerFactory.CreateProcessorsContainer();

        public ITaskSet_Delete taskSet_Delete { get => _container.Resolve<ITaskSet_Delete>(); }
        public ITaskSet_GetAll taskSet_GetAll { get => _container.Resolve<ITaskSet_GetAll>(); }
        public ITaskSet_GetById taskSet_GetById { get => _container.Resolve<ITaskSet_GetById>(); }
        public ITaskSet_Post taskSet_Post { get => _container.Resolve<ITaskSet_Post>(); }
        public ITaskSet_Update taskSet_Update { get => _container.Resolve<ITaskSet_Update>(); }

        public ITask_Delete task_Delete { get => _container.Resolve<ITask_Delete>(); }
        public ITask_GetAll task_GetAll { get => _container.Resolve<ITask_GetAll>(); }
        public ITask_GetById task_GetById { get => _container.Resolve<ITask_GetById>(); }
        public ITask_Post task_Post { get => _container.Resolve<ITask_Post>(); }
        public ITask_Update task_Update { get => _container.Resolve<ITask_Update>(); }
    }
}
