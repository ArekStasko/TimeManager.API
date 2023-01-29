using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using TimeManager.DATA.Services.MessageQueuer;
using LanguageExt.Common;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Update : Processor<TaskController>, ITask_Update
    {
        public Task_Update(DataContext context, ILogger<TaskController> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Request<Task_> request)
        {
            try
            {
                var task = _context.Tasks.Single(act => act.Id == request.Data.Id);
                var data = request.Data;
                
                Task_ updatedTask = new Task_()
                {
                    Name = data.Name,
                    Description = data.Description,
                    Type = data.Type,
                    DateAdded = data.DateAdded,
                    DateCompleted = data.DateCompleted,
                    Deadline = data.Deadline,
                    Priority = data.Priority,
                    Completed = data.Completed,
                    UserId = request.userId
                };
                
                _context.Tasks.Remove(task);
                _context.Tasks.Add(updatedTask);

                bool succ = _mqManager.Publish(
                    updatedTask,
                    "entity.task.update",
                    "direct",
                    "task_Update"
               );

                if (!succ)
                {
                    _context.Tasks.Remove(updatedTask);
                    _context.Tasks.Add(task);
                    _context.SaveChanges();
                    return new Result<bool>(false);
                }

                _context.SaveChanges();

                _logger.LogInformation("Successfully completed Task_Post processor execution");
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<bool>(ex);
            }


        }
    }
}
