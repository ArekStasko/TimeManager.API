using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.ActivityControllers;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public class Activity_Delete : Processor<ActivityController>, IActivity_Delete
    {

        public Activity_Delete(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Activity>>>> Delete(Request<int> request)
        {
            Response<List<Activity>> response;
            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");
                var activity = _context.Activities.Single(act => act.Id == request.Data);
                _context.Activities.Remove(activity);
                _context.SaveChanges();

                IActivity_GetAll Activity_GetAll = ActivityProcessor_Factory.GetActivity_GetAll(_context, _logger);
                _logger.LogInformation("Activity succesfully deleted");
                return await Activity_GetAll.Get(request.Token);
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
