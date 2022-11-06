using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.CategoryProcessor;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Services.interfaces;

namespace TimeManager.DATA.Controllers.CategoryControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly ICategoryProcessors _processors;
        public CategoryController(ICategoryProcessors processors) => _processors = processors;


        [HttpPost(Name = "GetCategories")]
        public async Task<ActionResult<Response<List<Category>>>> Get(Request<string> request)
        {
            return Ok(await _processors.Category_Get(request.userId));
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Add(Request<Category> request)
        {
            return Ok(await _processors.Category_Add(request));
        }

        [HttpPost(Name = "DeleteCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Delete(Request<int> request)
        {
            return Ok(await _processors.Category_Delete(request.Data, request.userId));
        }

        [HttpPost(Name = "UpdateCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Update(Request<Category> request)
        {
            return Ok(await _processors.Category_Update(request));
        }
    }
}
