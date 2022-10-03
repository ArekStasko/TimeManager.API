using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public interface IActivity_Update
    {
        public Task<ActionResult<Response<List<Activity>>>> Update(Request<Activity> request);
    }
}
