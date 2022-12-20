using LanguageExt.Common;
using TimeManager.DATA.Data;


namespace TimeManager.DATA.Processors.TaskProcessor.Interfaces
{
    public interface ITask_Update
    {
        public Task<Result<bool>> Execute(Request<Data.Task_> request);
    }
}
