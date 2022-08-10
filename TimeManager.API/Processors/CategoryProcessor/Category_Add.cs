using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Add : Auth_Processor, ICategory_Add
    {
        public Category_Add(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<vwCategory>>>> Post(Request<Category> request)
        {
            Response<List<vwCategory>> response;
            try
            {
                if (!IsAuth(request.Token)) throw new Exception("You have to be logged in");

                _context.Categories.Add(request.Data);
                _context.SaveChanges();

                ICategory_Get Category_Get = new Category_Get(_context);
                return await Category_Get.Get(request.Token);
            }
            catch (Exception ex)
            {
                response = new Response<List<vwCategory>>(ex, "Whoops, something went wrong");
                return response;
            }

        }
    }
}
