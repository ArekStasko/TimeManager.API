using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.CategoryControllers;

namespace TimeManager.DATA.Processors.CategoryProcessor
{
    public class Category_Add : Processor<CategoryController>, ICategory_Add
    {
        public Category_Add(DataContext context, ILogger<CategoryController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Category>>>> Post(Request<Category> request)
        {
            Response<List<Category>> response;
            try
            {
                _context.Categories.Add(request.Data);
                _context.SaveChanges();

                ICategory_Get Category_Get = CategoryProcessor_Factory.GetCategory_Get(_context, _logger);
                _logger.LogInformation("Successfully added category");
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
