using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.ActivityControllers;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public class Activity_Add : Processor<ActivityController>, IActivity_Add
    {

        public Activity_Add(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Activity>>>> Post(Request<Activity> request)
        {
            Response<List<Activity>> response;
            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");
                if (request.Data.CategoryId == 0) throw new Exception("CategoryID is 0");
                Activity activity = request.Data;
                activity.UserId = request.Token.userId;
                _context.Activities.Add(activity);
                _context.SaveChanges();

                IActivity_GetAll activityProcessor = ActivityProcessor_Factory.GetActivity_GetAll(_context, _logger);
                _logger.LogInformation("User succesfully added");
                return await activityProcessor.Get(request.Token);
            }
            catch (Exception ex)
            {
                response = new Response<List<Activity>>(ex);
                _logger.LogError(ex.Message);
                return response;
            }

        }
    }
}
