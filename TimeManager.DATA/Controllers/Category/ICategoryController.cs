using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<Response<List<Category>>>> Get(Request<string> request);
        public Task<ActionResult<Response<List<Category>>>> Add(Request<Category> request);
        public Task<ActionResult<Response<List<Category>>>> Delete(Request<int> request);
        public Task<ActionResult<Response<List<Category>>>> Update(Request<Category> request);
    }
}
