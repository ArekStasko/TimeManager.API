using AutoMapper;
using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using TimeManager.DATA.Services.MessageQueuer;
using LanguageExt.Common;
using TimeManager.DATA.Data.DTO;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_Post : Processor<TaskController>, ITask_Post
    {

        public Task_Post(DataContext context, ILogger<TaskController> logger, IMQManager mqManager, IMapper mapper) : base(context, logger, mqManager, mapper) { }

        public async Task<Result<bool>> Execute(Request<TaskDTO> request)
        {            
            try
            {
                Task_ task = _mapper.Map<Task_>(request.Data);
                task.Id = Guid.NewGuid();
                task.UserId = request.userId;

                _context.Tasks.Add(task);
                _context.SaveChanges();
                
                bool succ = _mqManager.Publish(
                    task,
                    "entity.task.post",
                    "direct",
                    "task_Post"
                );

                if (!succ)
                {
                    _context.Tasks.Remove(task);
                    _context.SaveChanges();
                    return new Result<bool>(false);
                }

                _logger.LogInformation("Successfully completed Task_Post processor execution");
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
