using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.actTaskProcessor;
using TimeManager.DATA.Services.interfaces;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Controllers.ActTaskControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActTaskController : ControllerBase, IActTaskController
    {
        private readonly IActTaskProcessors _processors;
        private readonly IMQManager _mqManager;

        public ActTaskController(IActTaskProcessors processors, IMQManager mqManager)
        {
            _processors = processors;
            _mqManager = mqManager;
        } 


        [HttpPost(Name = "GetActivities")]
        public async Task<ActionResult<Response<List<Task>>>> Get(Request<string> request)
        {
            return Ok(await _processors.ActTask_Get(request.userId));
        }

        [HttpPost(Name = "GetActivityById")]
        public async Task<ActionResult<Response<Task>>> GetById(Request<int> request)
        {
            return Ok(await _processors.ActTask_GetById(request.Data, request.userId));
        }

        /*
        [HttpPost(Name = "GetActivitiesByCategory")]
        public async Task<ActionResult<Response<List<Activity>>>> GetByCategory(Request<int> request)
        {    
            return Ok(await _processors.GetByCategory(request.Data, request.userId));
        }
        */ 

        [HttpPost(Name = "PostActivity")]
        public async Task<ActionResult<Response<List<Task>>>> Post(Request<Data.ActTask> request)
        {
            try
            {
                var activity = _processors.ActTask_Post(request);

                _mqManager.Publish(
                    activity,
                    "entity.activity.post",
                    "direct",
                    "Activity_Post"
                );

                var activities = await _processors.ActTask_Get(request.userId);
                return Ok(activities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteActivity")]
        public async Task<ActionResult<Response<List<Task>>>> Delete(Request<int> request)
        {
            try
            {
                var activity = _processors.ActTask_Delete(request.Data, request.userId);

                _mqManager.Publish(
                    activity,
                    "entity.activity.delete",
                    "direct",
                    "Activity_Delete"
                );

                var activities = await _processors.ActTask_Get(request.userId);
                return Ok(activities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(Name = "UpdateActivity")]
        public async Task<ActionResult<Response<List<Task>>>> Update(Request<Data.ActTask> request)
        {
            try
            {
                var activity = await _processors.ActTask_Update(request);

                _mqManager.Publish(
                    activity,
                    "entity.activity.update",
                    "direct",
                    "Activity_Update"
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
