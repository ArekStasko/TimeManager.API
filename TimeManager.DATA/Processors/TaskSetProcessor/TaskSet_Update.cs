using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Update : Processor<ITaskSet_Update>, ITaskSet_Update
    {
        public TaskSet_Update(DataContext context, ILogger<ITaskSet_Update> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Request<TaskSet> request)
        {
            try
            {
                var taskSet = _context.TaskSets.Single(tsk => tsk.Id == request.Data.Id);
                _context.TaskSets.Remove(taskSet);
                _context.TaskSets.Add(request.Data);

                bool succ = _mqManager.Publish(
                   taskSet,
                   "entity.taskSet.update",
                   "direct",
                   "taskSet_Update"
               );

                if (!succ)
                {
                    _context.TaskSets.Remove(request.Data);
                    _context.TaskSets.Add(taskSet);
                    _context.SaveChanges();
                    return new Result<bool>(false);
                }

                _context.SaveChanges();

                _logger.LogInformation("Successfully completed TaskSet_Update processor execution");
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
