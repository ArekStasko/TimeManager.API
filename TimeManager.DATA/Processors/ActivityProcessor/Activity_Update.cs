using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActivityControllers;

namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public class Activity_Update : Processor<ActivityController>, IActivity_Update
    {
        public Activity_Update(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Activity>> Update(Request<Activity> request)
        {
            try
            {
                var act = _context.Activities.Single(act => act.Id == request.Data.Id);
                _context.Activities.Remove(act);

                IActivity_Post activity_Add = new Activity_Post(_context, _logger);
                return await activity_Add.Post(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }


        }
    }
}
