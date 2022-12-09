using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public interface ITask_GetByCategory
    {
        public Task<ActionResult<Response<List<Task>>>> Get(int categoryId, int userId);
    }
}
