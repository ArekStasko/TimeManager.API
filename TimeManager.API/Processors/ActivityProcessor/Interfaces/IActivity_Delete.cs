using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.ActivityProcessor
{
    public interface IActivity_Delete
    {
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Delete(Request<int> request);
    }
}
