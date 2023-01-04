using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using TimeManager.DATA.Services.MessageQueuer;
using LanguageExt.Common;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Update : Processor<TaskController>, ITask_Update
    {
        public Task_Update(DataContext context, ILogger<TaskController> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Request<Task_> request)
        {
            try
            {
                var task = _context.Tasks.Single(act => act.Id == request.Data.Id);

                _context.Tasks.Remove(task);

                _context.Tasks.Add(request.Data);

                bool succ = _mqManager.Publish(
                    task,
                    "entity.task.update",
                    "direct",
                    "task_Update"
               );

                if (!succ)
                {
                    _context.Tasks.Remove(request.Data);
                    _context.Tasks.Add(task);
                    _context.SaveChanges();
                    return new Result<bool>(false);
                }

                _context.SaveChanges();

                _logger.LogInformation("Successfully completed Task_Post processor execution");
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<bool>(ex);
            }


        }
    }
}
