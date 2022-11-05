using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.CategoryProcessor
{
    public interface ICategory_Get
    {
        public Task<ActionResult<Response<List<Category>>>> Get(int userId);
    }
}
