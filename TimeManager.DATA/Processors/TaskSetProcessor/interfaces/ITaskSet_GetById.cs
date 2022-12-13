using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_GetById
    {
        public Task<ActionResult<TaskSet>> Execute(Request<int> request);
    }
}
