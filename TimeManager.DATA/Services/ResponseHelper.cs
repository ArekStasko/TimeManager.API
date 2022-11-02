using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.ActivityProcessor;
using TimeManager.DATA.Controllers.ActivityControllers;
using Microsoft.AspNetCore.Mvc;

namespace TimeManager.DATA.Services
{
    public static class ResponseHelper
    {
        public static async Task<ActionResult<Response<List<Activity>>>> GetAllActivities(DataContext context, ILogger<ActivityController> logger, int userId)
        {
            IActivity_GetAll activityProcessor = ActivityProcessor_Factory.GetActivity_GetAll(context, logger);
            return await activityProcessor.Get(userId);
        }
    }
}
