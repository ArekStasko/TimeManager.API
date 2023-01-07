using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_GetById : Processor<ITaskSet_GetById>, ITaskSet_GetById
    {
        public TaskSet_GetById(DataContext context, ILogger<ITaskSet_GetById> logger) : base(context, logger) { }

        public async Task<Result<TaskSet>> Execute(int taskSetId, int userId)
        {
            try
            {
                var taskSet = _context.TaskSets.Single(tsk => tsk.Id == taskSetId && tsk.UserId == userId);

                _logger.LogInformation("Successfully completed TaskSet_GetById processor execution");
                return new Result<TaskSet>(taskSet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                return new Result<TaskSet>(ex);
            }
        }
    }
}
