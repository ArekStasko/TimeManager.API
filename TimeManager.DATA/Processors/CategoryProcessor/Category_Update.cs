using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.CategoryControllers;
using TimeManager.DATA.Services;

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
                _context.Categories.Add(request.Data);
                _context.SaveChanges();

                return await ResponseHelper.GetAllCategories(_context, _logger, request.userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Category>>(ex);
            }

        }

    }
}
