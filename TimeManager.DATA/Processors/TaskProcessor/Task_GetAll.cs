using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using Newtonsoft.Json;
using TimeManager.DATA.Controllers.ActTaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;


namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_GetAll : Processor<ActTaskSetController>, ITask_GetAll
    {
        public Task_GetAll(DataContext context, ILogger<ActTaskSetController> logger) : base(context, logger) { }
        public async Task<ActionResult<Response<List<Task_>>>> Execute(int userId)
        {
            try
            {
                var ActTasks = _context.ActTasks.ToList();
                ActTasks = ActTasks.Where(a => a.UserId == userId).ToList();
                return new Response<List<Task_>>(ActTasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<List<Data.Task_>>(ex); 
            }
        }
    }
}
