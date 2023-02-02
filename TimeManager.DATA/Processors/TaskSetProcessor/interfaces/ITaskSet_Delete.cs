using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_Delete
    {
        public Task<Result<bool>> Execute(Guid taskSetId, Guid userId);
    }
}
