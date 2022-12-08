using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public interface IActTask_GetByCategory
    {
        public Task<ActionResult<Response<List<Task>>>> Get(int categoryId, int userId);
    }
}
