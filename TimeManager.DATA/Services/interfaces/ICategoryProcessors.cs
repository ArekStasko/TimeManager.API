using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Services.interfaces
{
    public interface ICategoryProcessors
    {
        public Task<ActionResult<Response<List<Category>>>> Category_Add(Request<Category> request);
        public Task<ActionResult<Response<List<Category>>>> Category_Delete(int categoryId, int userId);
        public Task<ActionResult<Response<List<Category>>>> Category_Get(int userId);
        public Task<ActionResult<Response<List<Category>>>> Category_Update(Request<Category> request);
    }
}
