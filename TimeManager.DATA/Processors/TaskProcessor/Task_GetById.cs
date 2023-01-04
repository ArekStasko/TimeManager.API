using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using LanguageExt.Common;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_GetById : Processor<TaskController>, ITask_GetById
    {
        public Task_GetById(DataContext context, ILogger<TaskController> logger) : base(context, logger) { }

        public async Task<Result<Task_>> Execute(int taskId, int userId)
        {
            try
            {
                var tasks = _context.Tasks.ToList();
                var task = tasks.Single(tsk => tsk.Id == taskId && tsk.UserId == userId);
                
                return new Result<Task_>(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<Task_>(ex);
            }
          
        }

    }
}
