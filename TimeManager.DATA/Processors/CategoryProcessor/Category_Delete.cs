﻿using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.CategoryControllers;
using TimeManager.DATA.Services;

namespace TimeManager.DATA.Processors.CategoryProcessor
{
    public class Category_Delete : Processor<CategoryController>, ICategory_Delete
    {
        public Category_Delete(DataContext context, ILogger<CategoryController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<Category>>>> Delete(int categoryId, int userId)
        {
            try
            {
                var category = _context.Categories.Single(c => c.Id == categoryId && c.UserId == userId);
                _context.Categories.Remove(category);
                _context.SaveChanges();

                return await ResponseHelper.GetAllCategories(_context, _logger, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Category>>(ex);
            }

        }
    }
}
