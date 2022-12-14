using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Processors.TaskProcessor;
using TimeManager.DATA.Controllers.ActTaskControllers;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;

namespace TimeManager.DATA.Services
{
    public static class ResponseHelper
    {
        public static async Task<ActionResult<Response<List<Task_>>>> GetAllTasks(DataContext context, ILogger<ActTaskSetController> logger, int userId)
        {
            ITask_GetAll actTaskProcessor = new Task_GetAll(context, logger);
            return await actTaskProcessor.Execute(userId);
        }
    }
}
