using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Update : Processor<ActTaskSetController>, ITask_Update
    {
        public Task_Update(DataContext context, ILogger<ActTaskSetController> logger) : base(context, logger) { }

        public async Task<ActionResult<Task_>> Execute(Request<Data.Task_> request)
        {
            try
            {
                var act = _context.ActTasks.Single(act => act.Id == request.Data.Id);
                _context.ActTasks.Remove(act);

                ITask_Post actTask_Add = new Task_Post(_context, _logger);
                return await actTask_Add.Execute(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }


        }
    }
}
