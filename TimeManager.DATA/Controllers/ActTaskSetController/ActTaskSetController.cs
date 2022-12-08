using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.actTaskProcessor;
using TimeManager.DATA.Services.interfaces;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Controllers.ActTaskSetControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActTaskSetController : ControllerBase, IActTaskSetController
    {
        private readonly IActTaskSetProcessors _processors;
        private readonly IMQManager _mqManager;

        public ActTaskSetController(IActTaskSetProcessors processors, IMQManager mqManager)
        {
            _processors = processors;
            _mqManager = mqManager;
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
