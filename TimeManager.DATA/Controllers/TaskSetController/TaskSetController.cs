using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.TaskProcessor;
using TimeManager.DATA.Services.interfaces;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Controllers.ActTaskSetControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskSetController : ControllerBase, ITaskSetController
    {
        private readonly ITaskSetProcessors _processors;
        private readonly IMQManager _mqManager;

        public TaskSetController(ITaskSetProcessors processors, IMQManager mqManager)
        {
            _processors = processors;
            _mqManager = mqManager;
        } 

        [HttpPost(Name = "UpdateActivity")]
        public async Task<ActionResult<Response<List<TaskSet>>>> Update(Request<Data.Task_> request)
        {
            try
            {
                var activity = await _processors.Task_Update(request);

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
