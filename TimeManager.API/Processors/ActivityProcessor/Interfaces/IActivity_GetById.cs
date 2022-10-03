using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.ActivityProcessor
{
    public interface IActivity_GetById
    {
        public Task<ActionResult<Response<Activity>>> Get(Request<int> request);
    }
}
