using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Controllers.ActTaskSetControllers;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Post : Processor<ITaskSet_Post>, ITaskSet_Post
    {
        public TaskSet_Post(DataContext context, ILogger<ITaskSet_Post> logger) : base(context, logger) { }

        public async Task<ActionResult<TaskSet>> Execute(Request<TaskSet> request)
        {
            try
            {
                TaskSet taskSet = request.Data;
                taskSet.UserId = request.userId;
                _context.ActTaskSets.Add(taskSet);
                _context.SaveChanges();

                _logger.LogInformation("Successfully completed TaskSet_Post processor execution");
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
