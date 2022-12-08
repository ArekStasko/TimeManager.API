using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.actTaskProcessor;
using TimeManager.DATA.Controllers.ActTaskControllers;
using Microsoft.AspNetCore.Mvc;

namespace TimeManager.DATA.Services
{
    public static class ResponseHelper
    {
        public static async Task<ActionResult<Response<List<ActTask>>>> GetAllActTasks(DataContext context, ILogger<ActTaskController> logger, int userId)
        {
            IActTask_GetAll actTaskProcessor = new ActTask_GetAll(context, logger);
            return await actTaskProcessor.Get(userId);
        }
    }
}
