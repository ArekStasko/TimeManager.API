using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Delete : Processor<ITaskSet_Delete>, ITaskSet_Delete
    {
        public TaskSet_Delete(DataContext context, Logger<ITaskSet_Delete> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Request<TaskSet> request)
        {
            try
            {
                var taskSet = _context.TaskSets.Single(tsk => tsk.Id == request.Data.Id);
                _context.TaskSets.Remove(taskSet);
                _context.SaveChanges();

                _logger.LogInformation("Successfully completed TaskSet_Delete processor execution");
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
