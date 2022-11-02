using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public interface IActivity_GetById
    {
        public Task<ActionResult<Response<Activity>>> Get(Request<int> request);
    }
}
