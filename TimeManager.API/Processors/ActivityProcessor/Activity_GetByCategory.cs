using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.ActivityControllers;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public class Activity_GetByCategory : Processor<ActivityController>, IActivity_GetByCategory
    {
        public Activity_GetByCategory(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Activity>>>> Get(Request<int> request)
        {
            Response<List<Activity>> response;

            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");
                var activities = await _context.Activities.ToListAsync();
                activities = activities.Where(activity => activity.CategoryId == request.Data).ToList();

                response = new Response<List<Activity>>(activities);
                _logger.LogInformation("Successfully gotten category by id");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = new Response<List<Activity>>(ex);
                return response;
            }
        }
    }
}
