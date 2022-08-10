using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public interface IvwActivityCategory_GetById
    {
        public Task<ActionResult<Response<vwActivityCategory>>> Get(Request<int> request);
    }
}
