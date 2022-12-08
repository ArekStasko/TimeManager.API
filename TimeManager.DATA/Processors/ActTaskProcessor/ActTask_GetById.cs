using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;


namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public class ActTask_GetById : Processor<ActTaskController>, IActTask_GetById
    {
        public ActTask_GetById(DataContext context, ILogger<ActTaskController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<ActTask>>> Get(int actTaskId, int userId)
        {
            try
            {
                var ActTasks = await _context.ActTasks.ToListAsync();
                var actTask = ActTasks.Single(act => act.Id == actTaskId && act.UserId == userId);
                
                return new Response<Data.ActTask>(actTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<Data.ActTask>(ex);
            }
          
        }

    }
}
