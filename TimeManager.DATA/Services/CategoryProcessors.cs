using TimeManager.DATA.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.CategoryProcessor;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.CategoryControllers;

namespace TimeManager.DATA.Services
{
    public class CategoryProcessors : ICategoryProcessors
    {
        private readonly DataContext _context;
        private readonly ILogger<CategoryController> _logger;
        public CategoryProcessors(DataContext context, ILogger<CategoryController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Task<ActionResult<Response<List<Category>>>> Category_Add(Request<Category> request)
        {
            ICategory_Add processor = new Category_Add(_context, _logger);
            return processor.Post(request);
        }
        public Task<ActionResult<Response<List<Category>>>> Category_Delete(int categoryId, int userId)
        {
            ICategory_Delete processor = new Category_Delete(_context, _logger);
            return processor.Delete(categoryId, userId);
        }
        public Task<ActionResult<Response<List<Category>>>> Category_Get(int userId)
        {
            ICategory_Get processor = new Category_Get(_context, _logger);
            return processor.Get(userId);
        }
        public Task<ActionResult<Response<List<Category>>>> Category_Update(Request<Category> request)
        {
            ICategory_Update processor = new Category_Update(_context, _logger);
            return processor.Update(request);
        }
        }
    }
