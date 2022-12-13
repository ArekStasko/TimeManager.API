using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;
using TimeManager.DATA.Services;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Delete : Processor<ActTaskSetController>, ITask_Delete
    {

        public Task_Delete(DataContext context, ILogger<ActTaskSetController> logger) : base(context, logger) { }

        public async Task<ActionResult<Task_>> Execute(int taskId, int userId)
        {
            try
            {
                var task = _context.ActTasks.Single(tsk => tsk.Id == taskId);
                _context.ActTasks.Remove(task);
                _context.SaveChanges();

                _logger.LogInformation("Successfully completed Task_Delete processor execution");
                return task;
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
