using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.CategoryControllers;

namespace TimeManager.DATA.Processors.CategoryProcessor
{
    public class Category_Update : Processor<CategoryController>, ICategory_Update
    {
        public Category_Update(DataContext context, ILogger<CategoryController> logger) : base(context, logger) {}

        public async Task<ActionResult<Response<List<Category>>>> Update(Request<Category> request)
        {
            try
            {
                var cat = _context.Categories.Single(c => c.Id == request.Data.Id);
                _context.Categories.Remove(cat);

                ICategory_Add Category_Add = CategoryProcessor_Factory.GetCategory_Add(_context, _logger);
                _logger.LogInformation("Successfully updated category");
                return await Category_Add.Post(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Category>>(ex);
            }

        }

    }
}
