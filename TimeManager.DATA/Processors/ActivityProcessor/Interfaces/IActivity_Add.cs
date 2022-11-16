using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public interface IActivity_Add
    {
        public Task<ActionResult<Activity>> Post(Request<Activity> request);
    }
}
