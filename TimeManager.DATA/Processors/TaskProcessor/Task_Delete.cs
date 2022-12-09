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

        public async Task<ActionResult<Task_>> Execute(int actTaskId, int userId)
        {
            try
            {
                var actTask = _context.ActTasks.Single(act => act.Id == actTaskId);
                _context.ActTasks.Remove(actTask);
                _context.SaveChanges();

                return actTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }

        }
    }
}
