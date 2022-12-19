using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskProcessor.Interfaces
{
    public interface ITask_Post
    {
            public Task<Result<bool>> Execute(Request<Task_> request);
    }
}
