using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Controllers.TaskSetControllers;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_GetById : Processor<TaskSetController>, ITaskSet_GetById
    {
        public TaskSet_GetById(DataContext context, ILogger<TaskSetController> logger) : base(context, logger) { }

        public async Task<Result<TaskSet>> Execute(Guid taskSetId, int userId)
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
