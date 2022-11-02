using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.CategoryProcessor
{
    public interface ICategory_Add
    {
        public Task<ActionResult<Response<List<Category>>>> Post(Request<Category> request);
    }
}
