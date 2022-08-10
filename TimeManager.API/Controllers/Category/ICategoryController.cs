using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Authentication;

namespace TimeManager.API.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<Response<List<vwCategory>>>> Get(Token token);
        public Task<ActionResult<Response<List<vwCategory>>>> Add(Request<Category> request);
        public Task<ActionResult<Response<List<vwCategory>>>> Delete(Request<int> request);
        public Task<ActionResult<Response<List<vwCategory>>>> Update(Request<Category> request);
    }
}
