using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;
using TimeManager.DATA.Services;


namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Post : Processor<ActTaskSetController>, ITask_Post
    {

        public Task_Post(DataContext context, ILogger<ActTaskSetController> logger) : base(context, logger) { }

        public async Task<ActionResult<Task_>> Execute(Request<Task_> request)
        {            
            try
            {
                Task_ actTask = request.Data;
                actTask.UserId = request.userId;
                _context.ActTasks.Add(actTask);
                _context.SaveChanges();

                _logger.LogInformation("Successfully completed Task_Post processor execution");
                return actTask;
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                throw new Exception(ex.Message);
            }

        }
    }
}
