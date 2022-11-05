﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.CategoryProcessor;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Controllers.CategoryControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly DataContext _context;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(DataContext context, ILogger<CategoryController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost(Name = "GetCategories")]
        public async Task<ActionResult<Response<List<Category>>>> Get(Request<string> request)
        {
            ICategory_Get Category_Get = CategoryProcessor_Factory.GetCategory_Get(_context, _logger);
            return Ok(await Category_Get.Get(request.userId));
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Add(Request<Category> request)
        {
            ICategory_Add Category_Add = CategoryProcessor_Factory.GetCategory_Add(_context, _logger);
            return Ok(await Category_Add.Post(request));
        }

        [HttpPost(Name = "DeleteCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Delete(Request<int> request)
        {
            ICategory_Delete Category_Delete = CategoryProcessor_Factory.GetCategory_Delete(_context, _logger);
            return Ok(Category_Delete.Delete(request.Data, request.userId));
        }

        [HttpPost(Name = "UpdateCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Update(Request<Category> request)
        {
            ICategory_Update Category_Update = CategoryProcessor_Factory.GetCategory_Update(_context, _logger);
            return Ok(Category_Update.Update(request));
        }
    }
}
