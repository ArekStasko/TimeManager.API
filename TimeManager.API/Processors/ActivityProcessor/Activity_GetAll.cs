using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using Newtonsoft.Json;


namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_GetAll : Processor, IvwActivityCategory_GetAll
    {
        public vwActivityCategory_GetAll(DataContext context) : base(context) { }
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Get(Token token)
        {
            Response<List<vwActivityCategory>> response;
            try
            {
                if (!Auth.IsAuth(token)) throw new Exception("You have to be logged in");

                var activities = _context.vwActivityCategory.ToList();
                activities = activities.Where(a => a.UserId == token.userId).ToList();
                response = new Response<List<vwActivityCategory>>(activities);   
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<vwActivityCategory>>(ex);
                return response;
            }
        }
    }
}
