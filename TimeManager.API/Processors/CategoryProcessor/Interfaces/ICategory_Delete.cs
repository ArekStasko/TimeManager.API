using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public interface ICategory_Delete
    {
        public Task<ActionResult<Response<List<Category>>>> Delete(Request<int> request);
    }
}
