﻿using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.ActivityProcessor;


namespace TimeManager.DATA.Controllers.ActivityControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase, IActivityController
    {
        private readonly DataContext _context;
        private readonly ILogger<ActivityController> _logger;
        public ActivityController(DataContext context, ILogger<ActivityController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost(Name = "GetActivities")]
        public async Task<ActionResult<Response<List<Activity>>>> Get(Request<string> request)
        {
            IActivity_GetAll vwActivityCategory_GetAll = ActivityProcessor_Factory.GetActivity_GetAll(_context, _logger);
            var activities = await vwActivityCategory_GetAll.Get(request.userId);
            return Ok(activities);
        }

        [HttpPost(Name = "GetvwActivityCategoryById")]
        public async Task<ActionResult<Response<Activity>>> GetById(Request<int> request)
        {
            IActivity_GetById vwActivityCategory_GetById = ActivityProcessor_Factory.GetActivity_GetById(_context, _logger);
            return Ok(await vwActivityCategory_GetById.Get(request.Data, request.userId));
        }

        [HttpPost(Name = "GetActivitiesByCategory")]
        public async Task<ActionResult<Response<List<Activity>>>> GetByCategory(Request<int> request)
        {
            IActivity_GetByCategory vwActivityCategory_GetByCategory = ActivityProcessor_Factory.GetActivity_GetByCategory(_context, _logger);
            return Ok(await vwActivityCategory_GetByCategory.Get(request.Data, request.userId));
        }

        [HttpPost(Name = "AddvwActivityCategory")]
        public async Task<ActionResult<Response<List<Activity>>>> Add(Request<Activity> request)
        {
            IActivity_Add vwActivityCategory_Add = ActivityProcessor_Factory.GetActivity_Add(_context, _logger);
            return Ok(vwActivityCategory_Add.Post(request));          
        }

        [HttpDelete(Name = "DeletevwActivityCategory")]
        public async Task<ActionResult<Response<List<Activity>>>> Delete(Request<int> request)
        {
            IActivity_Delete vwActivityCategory_Delete = ActivityProcessor_Factory.GetActivity_Delete(_context, _logger);
            return Ok(vwActivityCategory_Delete.Delete(request.Data, request.userId));
        }

        [HttpPost(Name = "UpdatevwActivityCategory")]
        public async Task<ActionResult<Response<List<Activity>>>> Update(Request<Activity> request)
        {
            IActivity_Update vwActivityCategory_Update = ActivityProcessor_Factory.GetActivity_Update(_context, _logger);
            return Ok(vwActivityCategory_Update.Update(request));
        }
    }
}
