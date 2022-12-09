using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public interface ITask_GetById
    {
        public Task<ActionResult<Response<Task_>>> Get(int actTaskId, int userId);
    }
}
