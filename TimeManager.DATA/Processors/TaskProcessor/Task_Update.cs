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

        public async Task<Result<bool>> Execute(Request<Data.Task_> request)
        {
            try
            {
                var task = _context.Tasks.Single(act => act.Id == request.Data.Id);

                _mqManager.Publish(
                    task,
                    "entity.activity.update",
                    "direct",
                    "Task_Update"
               );

                _context.Tasks.Remove(task);

                _mqManager.Publish(
                    task,
                    "entity.activity.post",
                    "direct",
                    "Task_Post"
                );

                _context.Tasks.Add(task);
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
