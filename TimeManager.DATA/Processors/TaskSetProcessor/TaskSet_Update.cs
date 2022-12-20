using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Update : Processor<ITaskSet_Update>, ITaskSet_Update
    {
        public TaskSet_Update(DataContext context, Logger<ITaskSet_Update> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Request<TaskSet> request)
        {
            try
            {
                var taskSet = _context.ActTaskSets.Single(tsk => tsk.Id == request.Data.Id);
                _context.ActTaskSets.Remove(taskSet);

                taskSet = request.Data;
                taskSet.UserId = request.userId;
                _context.ActTaskSets.Add(taskSet);
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
