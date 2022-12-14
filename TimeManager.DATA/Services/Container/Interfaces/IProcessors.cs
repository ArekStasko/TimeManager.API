using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using TimeManager.DATA.Processors.TaskSetProcessor;

namespace TimeManager.DATA.Services.Container
{
    public interface IProcessors
    {
        public ITaskSet_Delete taskSet_Delete { get; }
        public ITaskSet_GetAll taskSet_GetAll { get; }
        public ITaskSet_GetById taskSet_GetById { get; }
        public ITaskSet_Post taskSet_Post { get; }
        public ITaskSet_Update taskSet_Update { get; }

        public ITask_Delete task_Delete { get; }
        public ITask_GetAll task_GetAll { get; }
        public ITask_GetById task_GetById { get; }
        public ITask_Post task_Post { get; }
        public ITask_Update task_Update { get; }
    }
}
