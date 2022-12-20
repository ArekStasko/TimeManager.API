using LanguageExt.Common;

namespace TimeManager.DATA.Processors.TaskProcessor.Interfaces
{
    public interface ITask_Delete
    {
        public Task<Result<bool>> Execute(int actTaskId, int userId);
    }
}
