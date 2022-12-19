using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using LanguageExt.Common;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_GetById : Processor<TaskController>, ITask_GetById
    {
        public Task_GetById(DataContext context, ILogger<TaskController> logger) : base(context, logger) { }

        public async Task<Result<Task_>> Execute(int actTaskId, int userId)
        {
            try
            {
                var ActTasks = await _context.ActTasks.ToListAsync();
                var actTask = ActTasks.Single(act => act.Id == actTaskId && act.UserId == userId);
                
                return new Result<Task_>(actTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<Task_>(ex);
            }
          
        }

    }
}
