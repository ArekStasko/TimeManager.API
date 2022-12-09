using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor.interfaces
{
    public interface ITaskSet_GetAll
    {
        public Task<ActionResult<TaskSet>> Execute(int userId);
    }
}
