using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using Newtonsoft.Json;
using TimeManager.DATA.Controllers.ActivityControllers;


namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public class Activity_GetAll : Processor<ActivityController>, IActivity_GetAll
    {
        public Activity_GetAll(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }
        public async Task<ActionResult<Response<List<Activity>>>> Get(int userId)
        {
            try
            {
                var activities = _context.Activities.ToList();
                activities = activities.Where(a => a.UserId == userId).ToList();
                return new Response<List<Activity>>(activities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Activity>>(ex); 
            }
        }
    }
}
