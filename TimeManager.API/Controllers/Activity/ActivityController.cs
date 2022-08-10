using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data.Response;
using TimeManager.API.Data;
using TimeManager.API.Processors.vwActivityCategoryProcessor;
using TimeManager.API.Authentication;


namespace TimeManager.API.Controllers.vwActivityCategoryControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase, IActivityController
    {
        private readonly DataContext _context;
        public ActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "GetActivities")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Get(Token token)
        {
            IvwActivityCategory_GetAll vwActivityCategory_GetAll = ActivityProcessor_Factory.GetvwActivityCategory_GetAll(_context);
            var activities = await vwActivityCategory_GetAll.Get(token);
            return Ok(activities);
        }

        [HttpPost(Name = "GetvwActivityCategoryById")]
        public async Task<ActionResult<Response<vwActivityCategory>>> GetById(Request<int> request)
        {
            IvwActivityCategory_GetById vwActivityCategory_GetById = ActivityProcessor_Factory.GetvwActivityCategory_GetById(_context);
            return Ok(await vwActivityCategory_GetById.Get(request));
        }

        [HttpPost(Name = "GetActivitiesByCategory")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> GetByCategory(Request<int> request)
        {
            IvwActivityCategory_GetByCategory vwActivityCategory_GetByCategory = ActivityProcessor_Factory.GetvwActivityCategory_GetByCategory(_context);
            return Ok(await vwActivityCategory_GetByCategory.Get(request));
        }

        [HttpPost(Name = "AddvwActivityCategory")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Add(Request<Activity> request)
        {
            IActivity_Add vwActivityCategory_Add = ActivityProcessor_Factory.GetActivity_Add(_context);
            return Ok(vwActivityCategory_Add.Post(request));          
        }

        [HttpDelete(Name = "DeletevwActivityCategory")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Delete(Request<int> request)
        {
            IActivity_Delete vwActivityCategory_Delete = ActivityProcessor_Factory.GetActivity_Delete(_context);
            return Ok(vwActivityCategory_Delete.Delete(request));
        }

        [HttpPost(Name = "UpdatevwActivityCategory")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Update(Request<Activity> request)
        {
            IActivity_Update vwActivityCategory_Update = ActivityProcessor_Factory.GetActivity_Update(_context);
            return Ok(vwActivityCategory_Update.Update(request));
        }
    }
}
