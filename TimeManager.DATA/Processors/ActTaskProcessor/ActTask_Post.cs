using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;
using TimeManager.DATA.Services;


namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public class ActTask_Post : Processor<ActTaskSetController>, IActTask_Post
    {

        public ActTask_Post(DataContext context, ILogger<ActTaskSetController> logger) : base(context, logger) { }

        public async Task<ActionResult<ActTask>> Post(Request<ActTask> request)
        {            
            try
            {
                //if (request.Data.CategoryId == 0) throw new Exception("CategoryID is 0");
                Data.ActTask actTask = request.Data;
                actTask.UserId = request.userId;
                _context.ActTasks.Add(actTask);
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
