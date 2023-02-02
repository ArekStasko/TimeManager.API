using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskProcessor.Interfaces
{
    public interface ITask_GetById
    {
        public Task<Result<Task_>> Execute(Guid taskId, Guid userId);
    }
}
