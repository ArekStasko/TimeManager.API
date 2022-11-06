using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.ActivityProcessor;
using TimeManager.DATA.Controllers.ActivityControllers;
using TimeManager.DATA.Controllers.CategoryControllers;
using TimeManager.DATA.Processors.CategoryProcessor;
using Microsoft.AspNetCore.Mvc;

namespace TimeManager.DATA.Services
{
    public static class ResponseHelper
    {
        public static async Task<ActionResult<Response<List<Activity>>>> GetAllActivities(DataContext context, ILogger<ActivityController> logger, int userId)
        {
            IActivity_GetAll activityProcessor = new Activity_GetAll(context, logger);
            return await activityProcessor.Get(userId);
        }
        public static async Task<ActionResult<Response<List<Category>>>> GetAllCategories(DataContext context, ILogger<CategoryController> logger, int userId)
        {
            ICategory_Get activityProcessor = new Category_Get(context, logger);
            return await activityProcessor.Get(userId);
        }
    }
}
