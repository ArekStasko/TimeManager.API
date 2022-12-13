using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Update : Processor<ITaskSet_Update>, ITaskSet_Update
    {
        public TaskSet_Update(DataContext context, Logger<ITaskSet_Update> logger) : base(context, logger) { }

        public async Task<ActionResult<TaskSet>> Execute(Request<TaskSet> request)
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
                return taskSet;
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
