using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Update : Processor<TaskController>, ITask_Update
    {
        public Task_Update(DataContext context, ILogger<TaskController> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<ActionResult<Task_>> Execute(Request<Data.Task_> request)
        {
            try
            {
                var task = _context.ActTasks.Single(act => act.Id == request.Data.Id);

                _mqManager.Publish(
                    task,
                    "entity.activity.update",
                    "direct",
                    "Task_Update"
               );

                _context.ActTasks.Remove(task);

                ITask_Post Task_Add = new Task_Post(_context, _logger, _mqManager);
                return await Task_Add.Execute(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }


        }
    }
}
