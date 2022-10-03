using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<Response<List<Category>>>> Get(Token token);
        public Task<ActionResult<Response<List<Category>>>> Add(Request<Category> request);
        public Task<ActionResult<Response<List<Category>>>> Delete(Request<int> request);
        public Task<ActionResult<Response<List<Category>>>> Update(Request<Category> request);
    }
}
