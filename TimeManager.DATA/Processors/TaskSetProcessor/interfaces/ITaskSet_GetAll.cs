using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_GetAll
    {
        public Task<Result<List<TaskSet>>> Execute(int userId);
    }
}
