using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Delete : Processor<ITaskSet_Delete>, ITaskSet_Delete
    {
        public TaskSet_Delete(DataContext context, Logger<ITaskSet_Delete> logger) : base(context, logger) { }

        public async Task<ActionResult<List<TaskSet>>> Execute(Request<TaskSet> request)
        {
            try
            {
                var taskSet = _context.ActTaskSets.Single(tsk => tsk.Id == request.Data.Id);
                _context.ActTaskSets.Remove(taskSet);
                _context.SaveChanges();

                _logger.LogInformation("Successfully completed TaskSet_Delete processor execution");
                return _context.ActTaskSets.ToList();
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
