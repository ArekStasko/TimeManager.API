using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using TimeManager.DATA.Services.MessageQueuer;
using LanguageExt.Common;
using TimeManager.DATA.Data.DTO;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Update : Processor<TaskController>, ITask_Update
    {
        public Task_Update(DataContext context, ILogger<TaskController> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Request<TaskDTO> request)
        {
            try
            {
                var task = _context.Tasks.Single(act => act.Id == request.Data.Id);
                
                task.Name = request.Data.Name;
                task.Description = request.Data.Description;
                task.Type = request.Data.Type;
                task.DateAdded = request.Data.DateAdded;
                task.DateCompleted = request.Data.DateCompleted;
                task.Deadline = request.Data.Deadline;
                task.Priority = request.Data.Priority;
                task.Completed = request.Data.Completed;
                task.UserId = request.userId;

                bool succ = _mqManager.Publish(
                    task,
                    "entity.task.update",
                    "direct",
                    "task_Update"
               );

                if (!succ) return new Result<bool>(false);

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
