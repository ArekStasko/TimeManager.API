using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using Newtonsoft.Json;
using TimeManager.API.Controllers.ActivityControllers;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public class Activity_GetAll : Processor<ActivityController>, IActivity_GetAll
    {
        public Activity_GetAll(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }
        public async Task<ActionResult<Response<List<Activity>>>> Get(Token token)
        {
            Response<List<Activity>> response;
            try
            {
                if (!Auth.IsAuth(token)) throw new Exception("You have to be logged in");

                var activities = _context.Activities.ToList();
                activities = activities.Where(a => a.UserId == token.userId).ToList();
                response = new Response<List<Activity>>(activities);
                _logger.LogInformation("Successfully gotten activities");
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
