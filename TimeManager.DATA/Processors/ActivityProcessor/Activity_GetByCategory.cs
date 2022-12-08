using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActivityControllers;


namespace TimeManager.DATA.Processors.ActivityProcessor
{
    /*
    public class Activity_GetByCategory : Processor<ActivityController>, IActivity_GetByCategory
    {
        public Activity_GetByCategory(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Activity>>>> Get(int categoryId, int userId)
        {
            try
            {
                var activities = await _context.Activities.ToListAsync();
                activities = activities.Where(activity => activity.CategoryId == categoryId && activity.UserId == userId).ToList();

                return new Response<List<Activity>>(activities); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Activity>>(ex);
            }
        }
    }
    */
}
