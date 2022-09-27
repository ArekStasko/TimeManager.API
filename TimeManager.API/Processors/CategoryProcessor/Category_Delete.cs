﻿using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;
using TimeManager.API.Controllers.CategoryControllers;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Delete : Processor<CategoryController>, ICategory_Delete
    {
        public Category_Delete(DataContext context, ILogger<CategoryController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<vwCategory>>>> Delete(Request<int> request)
        {
            Response<List<vwCategory>> response;
            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");

                var category = _context.Categories.Single(c => c.Id == request.Data);
                _context.Categories.Remove(category);
                _context.SaveChanges();

                ICategory_Get Category_Get = CategoryProcessor_Factory.GetCategory_Get(_context, _logger);
                return await Category_Get.Get(request.Token);
            }
            catch (Exception ex)
            {
                response = new Response<List<vwCategory>>(ex);
                return response;
            }

        }
    }
}
