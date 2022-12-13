using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_Update
    {
        public Task<ActionResult<TaskSet>> Execute(Request<TaskSet> request);
    }
}
