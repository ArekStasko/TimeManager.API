using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActivityControllers;
using TimeManager.DATA.Services;


namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public class Activity_Add : Processor<ActivityController>, IActivity_Add
    {

        public Activity_Add(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Activity>>>> Post(Request<Activity> request)
        {            
            try
            {
                if (request.Data.CategoryId == 0) throw new Exception("CategoryID is 0");
                Activity activity = request.Data;
                activity.UserId = request.userId;
                _context.Activities.Add(activity);
                _context.SaveChanges();

                return await ResponseHelper.GetAllActivities(_context, _logger, request.userId);
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex.Message);
                return new Response<List<Activity>>(ex);
            }

        }
    }
}
