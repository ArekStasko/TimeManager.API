using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public interface ITask_GetAll
    {
        public Task<ActionResult<Response<List<Task_>>>> Execute(int userId);
    }
}
