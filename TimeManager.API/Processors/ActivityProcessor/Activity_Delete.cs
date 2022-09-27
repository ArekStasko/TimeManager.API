using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.vwActivityCategoryControllers;


namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_Delete : Processor<ActivityController>, IActivity_Delete
    {

        public vwActivityCategory_Delete(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Delete(Request<int> request)
        {
            Response<List<vwActivityCategory>> response;
            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");
                var activity = _context.Activities.Single(act => act.Id == request.Data);
                _context.Activities.Remove(activity);
                _context.SaveChanges();

                IvwActivityCategory_GetAll vwActivityCategory_GetAll = ActivityProcessor_Factory.GetvwActivityCategory_GetAll(_context, _logger);
                _logger.LogInformation("Activity succesfully deleted");
                return await vwActivityCategory_GetAll.Get(request.Token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = new Response<List<vwActivityCategory>>(ex);
                return response;
            }

        }
    }
}
