using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public interface ITask_Delete
    {
        public Task<ActionResult<Task_>> Delete(int actTaskId, int userId);
    }
}
