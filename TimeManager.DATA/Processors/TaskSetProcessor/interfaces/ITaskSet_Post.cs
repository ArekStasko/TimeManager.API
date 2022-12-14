using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_Post
    {
        public Task<Result<bool>> Execute(Request<TaskSet> request);
    }
}
