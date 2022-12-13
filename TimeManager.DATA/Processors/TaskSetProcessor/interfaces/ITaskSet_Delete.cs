using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_Delete
    {
        public Task<ActionResult<List<TaskSet>>> Execute(Request<TaskSet> request);
    }
}
