using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Controllers.ActivityControllers
{
    public interface IActivityController
    {
        public Task<ActionResult<Response<List<Activity>>>> Get(Request<string> request);
        public Task<ActionResult<Response<Activity>>> GetById(Request<int> request);
        public Task<ActionResult<Response<List<Activity>>>> GetByCategory(Request<int> request);
        public Task<ActionResult<Response<List<Activity>>>> Add(Request<Activity> request);
        public Task<ActionResult<Response<List<Activity>>>> Delete(Request<int> request);
        public Task<ActionResult<Response<List<Activity>>>> Update(Request<Activity> request);

    }
}
