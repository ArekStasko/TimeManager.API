using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using Newtonsoft.Json;
using TimeManager.DATA.Controllers.ActivityControllers;
using TimeManager.DATA.Processors.ActivityProcessor;
using TimeManager.DATA.Services.interfaces;

namespace TimeManager.DATA.Services
{
    public class ActivityProcessors : IActivityProcessors
    {
        public readonly DataContext _context;
        private readonly ILogger<ActivityController> _logger;

        public ActivityProcessors(DataContext context, ILogger<ActivityController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public Task<ActionResult<Response<List<Activity>>>> Get(int userId)
        {
            IActivity_GetAll processor = new Activity_GetAll(_context, _logger);
            return processor.Get(userId);
        }

        public Task<ActionResult<Response<Activity>>> GetById(int activityId, int userId)
        {
            IActivity_GetById processor = new Activity_GetById(_context, _logger);
            return processor.Get(activityId, userId);
        }

        public Task<ActionResult<Response<List<Activity>>>> GetByCategory(int categoryId, int userId)
        {
            IActivity_GetByCategory processor = new Activity_GetByCategory(_context, _logger);
            return processor.Get(categoryId, userId);
        }

        public Task<ActionResult<Response<List<Activity>>>> Add_Activity(Request<Activity> request)
        {
            IActivity_Add processor = new Activity_Add(_context, _logger);
            return processor.Post(request);
        }

        public Task<ActionResult<Response<List<Activity>>>> Delete_Activity(int activityId, int userId)
        {
            IActivity_Delete processor = new Activity_Delete(_context, _logger);
            return processor.Delete(activityId, userId);
        }

        public Task<ActionResult<Response<List<Activity>>>> Update_Activity(Request<Activity> request)
        {
            IActivity_Update processor = new Activity_Update(_context, _logger);
            return processor.Update(request);
        }
      }
    }
