using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;
using TimeManager.DATA.Services;

namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public class ActTask_Delete : Processor<ActTaskSetController>, IActTask_Delete
    {

        public ActTask_Delete(DataContext context, ILogger<ActTaskSetController> logger) : base(context, logger) { }

        public async Task<ActionResult<ActTask>> Delete(int actTaskId, int userId)
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
