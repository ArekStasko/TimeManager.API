using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Services.Validation;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Update : Processor, ICategory_Update
    {
        public Category_Update(DataContext context) : base(context) {}

        public async Task<ActionResult<Response<List<vwCategory>>>> Update(Request<Category> request)
        {
            Response<List<vwCategory>> response;

            try
            {
                if (!Auth.IsAuth(request.Token)) throw new Exception("You have to be logged in");

                var cat = _context.Categories.Single(c => c.Id == request.Data.Id);
                _context.Categories.Remove(cat);

                ICategory_Add Category_Add = CategoryProcessor_Factory.GetCategory_Add(_context);
                return await Category_Add.Post(request);
            }
            catch (Exception ex)
            {
                response = new Response<List<vwCategory>>(ex, "Whoops, something went wrong");
                return response;
            }

        }

    }
}
