using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public interface ITask_Post
    {
            public Task<ActionResult<Task_>> Post(Request<Task_> request);
    }
}
