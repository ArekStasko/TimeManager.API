using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using Newtonsoft.Json;
using TimeManager.DATA.Controllers.ActTaskControllers;


namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public class ActTask_GetAll : Processor<ActTaskController>, IActTask_GetAll
    {
        public ActTask_GetAll(DataContext context, ILogger<ActTaskController> logger) : base(context, logger) { }
        public async Task<ActionResult<Response<List<ActTask>>>> Get(int userId)
        {
            try
            {
                var ActTasks = _context.ActTasks.ToList();
                ActTasks = ActTasks.Where(a => a.UserId == userId).ToList();
                return new Response<List<ActTask>>(ActTasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Data.ActTask>>(ex); 
            }
        }
    }
}
