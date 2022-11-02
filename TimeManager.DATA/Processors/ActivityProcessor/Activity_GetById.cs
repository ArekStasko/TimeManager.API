using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActivityControllers;


namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public class Activity_GetById : Processor<ActivityController>, IActivity_GetById
    {
        public Activity_GetById(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<Activity>>> Get(int activityId, int userId)
        {
            try
            {
                var activities = await _context.Activities.ToListAsync();
                var activity = activities.Single(act => act.Id == activityId && act.UserId == userId);
                
                return new Response<Activity>(activity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<Activity>(ex);
            }
          
        }

    }
}
