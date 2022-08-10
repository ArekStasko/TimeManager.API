using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public interface ICategory_Add
    {
        public Task<ActionResult<Response<List<vwCategory>>>> Post(Request<Category> request);
    }
}
