using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.ActivityControllers;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public class vwActivityCategory_GetById : Processor<ActivityController>, IvwActivityCategory_GetById
    {
        public vwActivityCategory_GetById(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<vwActivityCategory>>> Get(Request<int> request)
        {
            Response<vwActivityCategory> response;
            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");

                var activities = await _context.vwActivityCategory.ToListAsync();
                var activity = activities.Single(act => act.Id == request.Data);
                
                response = new Response<vwActivityCategory>(activity);
                _logger.LogInformation("Successfully gotten activity by id");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = new Response<vwActivityCategory>(ex);
                return response;
            }
          
        }

    }
}
