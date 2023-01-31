using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_GetById
    {
        public Task<Result<TaskSet>> Execute(Guid taskSetId, int userId);
    }
}
