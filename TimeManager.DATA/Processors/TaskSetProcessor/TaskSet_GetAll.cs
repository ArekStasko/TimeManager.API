using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_GetAll : Processor<ITaskSet_GetAll>, ITaskSet_GetAll
    {
        public TaskSet_GetAll(DataContext context, Logger<ITaskSet_GetAll> logger) : base(context, logger) { }

        public async Task<ActionResult<List<TaskSet>>> Execute(int userId)
        {
            try
            {
                var taskSets = _context.ActTaskSets.Where(tsk => tsk.UserId == userId).ToList();

                _logger.LogInformation("Successfully completed TaskSet_GetAll processor execution");
                return taskSets;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                throw new Exception(ex.Message);
            }
        }
    }
}
