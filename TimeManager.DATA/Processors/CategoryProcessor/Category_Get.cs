using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.CategoryControllers;

namespace TimeManager.DATA.Processors.CategoryProcessor
{
    public class Category_Get : Processor<CategoryController>, ICategory_Get
    {
        public Category_Get(DataContext context, ILogger<CategoryController> logger) : base(context, logger) {}

        public async Task<ActionResult<Response<List<Category>>>> Get(int userId)
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                categories = categories.Where(category => category.UserId == userId).ToList();

                return new Response<List<Category>>(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Category>>(ex);
            }
        }
    }
}
