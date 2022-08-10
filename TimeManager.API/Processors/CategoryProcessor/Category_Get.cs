using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Authentication;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Get : Auth_Processor, ICategory_Get
    {
        public Category_Get(DataContext context) : base(context) {}

        public async Task<ActionResult<Response<List<vwCategory>>>> Get(Token token)
        {
            Response<List<vwCategory>> response;
            try
            {
                if (!IsAuth(token)) throw new Exception("You have to be logged in");

                var categories = await _context.vwCategories.ToListAsync();
                response = new Response<List<vwCategory>>(categories);

                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<vwCategory>>(ex, "Whoops, something went wrong");
                return response;
            }
        }
    }
}
