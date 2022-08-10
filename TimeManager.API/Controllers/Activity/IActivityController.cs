using TimeManager.API.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data.Response;
using TimeManager.API.Authentication;


namespace TimeManager.API.Controllers.vwActivityCategoryControllers
{
    public interface IActivityController
    {
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Get(Token token);
        public Task<ActionResult<Response<vwActivityCategory>>> GetById(Request<int> request);
        public Task<ActionResult<Response<List<vwActivityCategory>>>> GetByCategory(Request<int> request);
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Add(Request<Activity> request);
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Delete(Request<int> request);
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Update(Request<Activity> request);
    }
}
