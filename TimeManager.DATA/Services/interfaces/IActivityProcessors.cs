using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActivityControllers;

namespace TimeManager.DATA.Services.interfaces
{
    public interface IActivityProcessors 
    {
        public Task<ActionResult<Response<List<Activity>>>> Get(int userId);
        public Task<ActionResult<Response<Activity>>> GetById(int activityId, int userId);
        public Task<ActionResult<Response<List<Activity>>>> GetByCategory(int categoryId, int userId);
        public Task<ActionResult<Response<List<Activity>>>> Add_Activity(Request<Activity> request);
        public Task<ActionResult<Response<List<Activity>>>> Delete_Activity(int activityId, int userId);
        public Task<ActionResult<Response<List<Activity>>>> Update_Activity(Request<Activity> request);

    }
}
