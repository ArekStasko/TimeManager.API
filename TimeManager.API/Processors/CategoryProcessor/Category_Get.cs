using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.CategoryControllers;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Get : Processor<CategoryController>, ICategory_Get
    {
        public Category_Get(DataContext context, ILogger<CategoryController> logger) : base(context, logger) {}

        public async Task<ActionResult<Response<List<vwCategory>>>> Get(Token token)
        {
            Response<List<vwCategory>> response;
            try
            {
                if (!Auth.IsAuth(token)) throw new Exception("You have to be logged in");

                var categories = await _context.vwCategories.ToListAsync();
                response = new Response<List<vwCategory>>(categories);

                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<vwCategory>>(ex);
                return response;
            }
        }
    }
}
