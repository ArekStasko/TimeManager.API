using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActivityControllers;
using TimeManager.DATA.Services;

namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public class Activity_Delete : Processor<ActivityController>, IActivity_Delete
    {

        public Activity_Delete(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Activity>>>> Delete(int activityId, int userId)
        {
            try
            {
                var activity = _context.Activities.Single(act => act.Id == activityId);
                _context.Activities.Remove(activity);
                _context.SaveChanges();

                return await ResponseHelper.GetAllActivities(_context, _logger, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Activity>>(ex);
            }

        }
    }
}
