using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.CategoryControllers;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Update : Processor<CategoryController>, ICategory_Update
    {
        public Category_Update(DataContext context, ILogger<CategoryController> logger) : base(context, logger) {}

        public async Task<ActionResult<Response<List<Category>>>> Update(Request<Category> request)
        {
            Response<List<Category>> response;

            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");

                var cat = _context.Categories.Single(c => c.Id == request.Data.Id);
                _context.Categories.Remove(cat);

                ICategory_Add Category_Add = CategoryProcessor_Factory.GetCategory_Add(_context, _logger);
                _logger.LogInformation("Successfully updated category");
                return await Category_Add.Post(request);
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
