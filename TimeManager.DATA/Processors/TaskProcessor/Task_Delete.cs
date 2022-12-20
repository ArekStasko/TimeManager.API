using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Services;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using LanguageExt.Common;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Delete : Processor<TaskController>, ITask_Delete
    {

        public Task_Delete(DataContext context, ILogger<TaskController> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(int taskId, int userId)
        {
            try
            {
                var task = _context.ActTasks.Single(tsk => tsk.Id == taskId && tsk.UserId == userId);

                _mqManager.Publish(
                    task,
                    "entity.activity.delete",
                    "direct",
                    "Task_Delete"
                );

                _context.ActTasks.Remove(task);
                _context.SaveChanges();

                _logger.LogInformation("Successfully completed Task_Delete processor execution");
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                return new Result<bool>(ex);
            }

        }
    }
}
