using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.CategoryControllers;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Add : Processor<CategoryController>, ICategory_Add
    {
        public Category_Add(DataContext context, ILogger<CategoryController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<vwCategory>>>> Post(Request<Category> request)
        {
            Response<List<vwCategory>> response;
            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");

                _context.Categories.Add(request.Data);
                _context.SaveChanges();

                ICategory_Get Category_Get = CategoryProcessor_Factory.GetCategory_Get(_context, _logger);
                _logger.LogInformation("Successfully added category");
                return await Category_Get.Get(request.Token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = new Response<List<vwCategory>>(ex);
                return response;
            }

        }
    }
}
