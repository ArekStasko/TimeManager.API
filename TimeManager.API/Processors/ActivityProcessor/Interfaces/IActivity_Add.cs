using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public interface IActivity_Add
    {
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Post(Request<Activity> request);
    }
}
