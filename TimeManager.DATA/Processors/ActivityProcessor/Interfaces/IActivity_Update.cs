using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public interface IActivity_Update
    {
        public Task<ActionResult<Activity>> Update(Request<Activity> request);
    }
}
