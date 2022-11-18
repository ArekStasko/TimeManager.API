using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.ActivityProcessor;
using TimeManager.DATA.Services.interfaces;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Controllers.ActivityControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase, IActivityController
    {
        private readonly IActivityProcessors _processors;
        private readonly IMQManager _mqManager;

        public ActivityController(IActivityProcessors processors, IMQManager mqManager)
        {
            _processors = processors;
            _mqManager = mqManager;
        } 


        [HttpPost(Name = "GetActivities")]
        public async Task<ActionResult<Response<List<Activity>>>> Get(Request<string> request)
        {
            return Ok(await _processors.Get(request.userId));
        }

        [HttpPost(Name = "GetActivityById")]
        public async Task<ActionResult<Response<Activity>>> GetById(Request<int> request)
        {
            return Ok(await _processors.GetById(request.Data, request.userId));
        }

        [HttpPost(Name = "GetActivitiesByCategory")]
        public async Task<ActionResult<Response<List<Activity>>>> GetByCategory(Request<int> request)
        {    
            return Ok(await _processors.GetByCategory(request.Data, request.userId));
        }

        [HttpPost(Name = "AddActivity")]
        public async Task<ActionResult<Response<List<Activity>>>> Add(Request<Activity> request)
        {
            try
            {
                var activity = _processors.Add_Activity(request);

                _mqManager.Publish(
                    activity,
                    "entity.activity.post",
                    "direct",
                    "activity-post"
                );

                var activities = await _processors.Get(request.userId);
                return Ok(activities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteActivity")]
        public async Task<ActionResult<Response<List<Activity>>>> Delete(Request<int> request)
        {
            try
            {
                var activity = _processors.Delete_Activity(request.Data, request.userId);

                _mqManager.Publish(
                    activity,
                    "entity.activity.delete",
                    "direct",
                    "activity-delete"
                );

                var activities = await _processors.Get(request.userId);
                return Ok(activities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(Name = "UpdateActivity")]
        public async Task<ActionResult<Response<List<Activity>>>> Update(Request<Activity> request)
        {
            try
            {
                var activity = await _processors.Update_Activity(request);

                _mqManager.Publish(
                    activity,
                    "entity.activity.update",
                    "direct",
                    "activity-update"
                );

                return Ok(activity);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
