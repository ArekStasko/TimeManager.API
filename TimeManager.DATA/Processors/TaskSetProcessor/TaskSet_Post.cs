using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Post : Processor<ITaskSet_Post>, ITaskSet_Post
    {
        public TaskSet_Post(DataContext context, ILogger<ITaskSet_Post> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Request<TaskSet> request)
        {
            try
            {
                TaskSet taskSet = request.Data;
                taskSet.UserId = request.userId;
                _context.TaskSets.Add(taskSet);

                bool succ = _mqManager.Publish(
                   taskSet,
                   "entity.taskSet.post",
                   "direct",
                   "taskSet_Post"
               );

                if (!succ)
                {
                    _context.TaskSets.Remove(taskSet);
                    _context.SaveChanges();
                    return new Result<bool>(false);
                }

                _context.SaveChanges();

                _logger.LogInformation("Successfully completed TaskSet_Post processor execution");
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
