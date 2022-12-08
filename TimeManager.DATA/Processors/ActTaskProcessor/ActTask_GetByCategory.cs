using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;


namespace TimeManager.DATA.Processors.actTaskProcessor
{
    /*
    public class actTask_GetByCategory : Processor<actTaskController>, IactTask_GetByCategory
    {
        public actTask_GetByCategory(DataContext context, ILogger<actTaskController> logger) : base(context, logger) { }

        public async Task<ActionResult<Response<List<actTask>>>> Get(int categoryId, int userId)
        {
            try
            {
                var ActTasks = await _context.ActTasks.ToListAsync();
                ActTasks = ActTasks.Where(actTask => actTask.CategoryId == categoryId && actTask.UserId == userId).ToList();

                return new Response<List<actTask>>(ActTasks); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<actTask>>(ex);
            }
        }
    }
    */
}
