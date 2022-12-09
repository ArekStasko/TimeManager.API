using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;


namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_GetById : Processor<ActTaskSetController>, ITask_GetById
    {
        public Task_GetById(DataContext context, ILogger<ActTaskSetController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<Task_>>> Get(int actTaskId, int userId)
        {
            try
            {
                var ActTasks = await _context.ActTasks.ToListAsync();
                var actTask = ActTasks.Single(act => act.Id == actTaskId && act.UserId == userId);
                
                return new Response<Data.Task_>(actTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<Data.Task_>(ex);
            }
          
        }

    }
}
