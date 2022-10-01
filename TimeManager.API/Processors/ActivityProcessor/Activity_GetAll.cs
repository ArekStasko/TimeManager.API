using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using Newtonsoft.Json;
using TimeManager.API.Controllers.ActivityControllers;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public class vwActivityCategory_GetAll : Processor<ActivityController>, IvwActivityCategory_GetAll
    {
        public vwActivityCategory_GetAll(DataContext context, ILogger<ActivityController> logger) : base(context, logger) { }
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Get(Token token)
        {
            Response<List<vwActivityCategory>> response;
            try
            {
                if (!Auth.IsAuth(token)) throw new Exception("You have to be logged in");

                var activities = _context.vwActivityCategory.ToList();
                activities = activities.Where(a => a.UserId == token.userId).ToList();
                response = new Response<List<vwActivityCategory>>(activities);
                _logger.LogInformation("Successfully gotten activities");
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
