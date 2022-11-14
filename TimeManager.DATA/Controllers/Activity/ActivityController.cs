using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.ActivityProcessor;
using TimeManager.DATA.Services.interfaces;
using TimeManager.DATA.Services.Publisher;

namespace TimeManager.DATA.Controllers.ActivityControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase, IActivityController
    {
        private readonly IActivityProcessors _processors;
        private readonly IPublisher _publisher;

        public ActivityController(IActivityProcessors processors, IPublisher publisher)
        {
            _processors = processors;
            _publisher = publisher;
        } 


        [HttpPost(Name = "GetActivities")]
        public async Task<ActionResult<Response<List<Activity>>>> Get(Request<string> request)
        {
            _publisher.Publish();
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
            return Ok(await _processors.Add_Activity(request));          
        }

        [HttpDelete(Name = "DeleteActivity")]
        public async Task<ActionResult<Response<List<Activity>>>> Delete(Request<int> request)
        {
            return Ok(await _processors.Delete_Activity(request.Data, request.userId));
        }

        [HttpPost(Name = "UpdateActivity")]
        public async Task<ActionResult<Response<List<Activity>>>> Update(Request<Activity> request)
        {
            return Ok(await _processors.Update_Activity(request));
        }

    }
}
