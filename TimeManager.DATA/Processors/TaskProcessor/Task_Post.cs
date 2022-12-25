using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using TimeManager.DATA.Services.MessageQueuer;
using LanguageExt.Common;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Post : Processor<TaskController>, ITask_Post
    {

        public Task_Post(DataContext context, ILogger<TaskController> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Request<Task_> request)
        {            
            try
            {
                Task_ task = request.Data;
                task.UserId = request.userId;


                bool succ =  _mqManager.Publish(
                    task,
                    "entity.task.post",
                    "direct",
                    "task_Post"
                );

                if (!succ) return new Result<bool>(false);

                _context.Tasks.Add(task);
                _context.SaveChanges();

                _logger.LogInformation("Successfully completed Task_Post processor execution");
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                return new Result<bool>(ex);
            }

        }
    }
}
