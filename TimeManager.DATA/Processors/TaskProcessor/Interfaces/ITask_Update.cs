using LanguageExt.Common;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.DTO;


namespace TimeManager.DATA.Processors.TaskProcessor.Interfaces
{
    public interface ITask_Update
    {
        public Task<Result<bool>> Execute(Request<TaskDTO> request);
    }
}
