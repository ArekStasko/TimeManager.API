using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.CategoryControllers;

namespace TimeManager.DATA.Processors.CategoryProcessor
{
    public class Category_Delete : Processor<CategoryController>, ICategory_Delete
    {
        public Category_Delete(DataContext context, ILogger<CategoryController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Category>>>> Delete(Request<int> request)
        {
            Response<List<Category>> response;
            try
            {
                var category = _context.Categories.Single(c => c.Id == request.Data);
                _context.Categories.Remove(category);
                _context.SaveChanges();

                ICategory_Get Category_Get = CategoryProcessor_Factory.GetCategory_Get(_context, _logger);
                _logger.LogInformation("Successfully deleted category");
                return await Category_Get.Get(new Request<string>() { userId = request.userId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = new Response<List<Category>>(ex);
                return response;
            }

        }
    }
}
