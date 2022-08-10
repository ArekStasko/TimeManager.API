using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public interface ICategory_Update
    {
        public Task<ActionResult<Response<List<vwCategory>>>> Update(Request<Category> request);
    }
}
