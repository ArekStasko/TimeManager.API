using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_GetAll
    {
        public Task<ActionResult<List<TaskSet>>> Execute(int userId);
    }
}
