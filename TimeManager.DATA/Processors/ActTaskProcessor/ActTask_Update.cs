using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;

namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public class ActTask_Update : Processor<ActTaskController>, IActTask_Update
    {
        public ActTask_Update(DataContext context, ILogger<ActTaskController> logger) : base(context, logger) { }

        public async Task<ActionResult<ActTask>> Update(Request<Data.ActTask> request)
        {
            try
            {
                var act = _context.ActTasks.Single(act => act.Id == request.Data.Id);
                _context.ActTasks.Remove(act);

                IActTask_Post actTask_Add = new ActTask_Post(_context, _logger);
                return await actTask_Add.Post(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }


        }
    }
}
