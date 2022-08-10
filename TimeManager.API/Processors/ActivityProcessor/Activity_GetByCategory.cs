using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_GetByCategory : Auth_Processor, IvwActivityCategory_GetByCategory
    {
        public vwActivityCategory_GetByCategory(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Get(Request<int> request)
        {
            Response<List<vwActivityCategory>> response;

            try
            {
                if (!IsAuth(request.Token)) throw new Exception("You have to be logged in");
                var activities = await _context.vwActivityCategory.ToListAsync();
                activities = activities.Where(activity => activity.CategoryId == request.Data).ToList();

                response = new Response<List<vwActivityCategory>>(activities);
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<vwActivityCategory>>(ex, "Whoops, something went wrong");
                return response;
            }
        }
    }
}
