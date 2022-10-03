using TimeManager.API.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Controllers.ActivityControllers
{
    public interface IActivityController
    {
        public Task<ActionResult<Response<List<Activity>>>> Get(Token token);
        public Task<ActionResult<Response<Activity>>> GetById(Request<int> request);
        public Task<ActionResult<Response<List<Activity>>>> GetByCategory(Request<int> request);
        public Task<ActionResult<Response<List<Activity>>>> Add(Request<Activity> request);
        public Task<ActionResult<Response<List<Activity>>>> Delete(Request<int> request);
        public Task<ActionResult<Response<List<Activity>>>> Update(Request<Activity> request);
    }
}
