using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public interface IActivity_GetByCategory
    {
        public Task<ActionResult<Response<List<Activity>>>> Get(int categoryId, int userId);
    }
}
