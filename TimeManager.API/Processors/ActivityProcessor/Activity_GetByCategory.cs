using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.vwActivityCategoryControllers;


namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_GetByCategory : Processor<ActivityController>, IvwActivityCategory_GetByCategory
    {
        public vwActivityCategory_GetByCategory(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Get(Request<int> request)
        {
            Response<List<vwActivityCategory>> response;

            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");
                var activities = await _context.vwActivityCategory.ToListAsync();
                activities = activities.Where(activity => activity.CategoryId == request.Data).ToList();

                response = new Response<List<vwActivityCategory>>(activities);
                _logger.LogInformation("Successfully gotten category by id");
                return response;
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
