using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.Container;
using LanguageExt.Common;
using TimeManager.DATA.Data.DTO;

namespace TimeManager.DATA.Controllers.TaskControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IProcessors _processors;

        public TaskController(IProcessors processors)
        {
            _processors = processors;
        }


        [HttpPost(Name = "GetTasks")]
        public async Task<IActionResult> Get(Request<string> request)
        {
            var processor = _processors.task_GetAll;
            if (processor == null) throw new ArgumentNullException(nameof(processor));

            var result = await processor.Execute(request.userId);

            return result.Match<IActionResult>(task =>
            {
                return CreatedAtAction(nameof(Get), task);
            }, exception =>
             {
                 return BadRequest(exception);
             });
        }

        [HttpPost(Name = "GetTaskById")]
        public async Task<IActionResult> GetById(Request<Guid> request)
        {
            var processor = _processors.task_GetById;
            if (processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request.Data, request.userId);

            return result.Match<IActionResult>(task =>
            {
                return CreatedAtAction(nameof(GetById), task);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }

        [HttpPost(Name = "PostTask")]
        public async Task<IActionResult> Post(Request<TaskDTO> request)
        {
            var processor = _processors.task_Post;
            if (processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request);

            return result.Match<IActionResult>(task =>
            {
                return CreatedAtAction(nameof(Post), task);
            }, exception =>
            {
                return BadRequest(exception);
            });

        }

        [HttpDelete(Name = "DeleteTask")]
        public async Task<IActionResult> Delete(Request<Guid> request)
        {

            var processor = _processors.task_Delete;
            if (processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request.Data, request.userId);

            return result.Match<IActionResult>(task =>
            {
                return CreatedAtAction(nameof(Delete), task);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }

        [HttpPost(Name = "UpdateTask")]
        public async Task<IActionResult> Update(Request<TaskDTO> request)
        {
            var processor = _processors.task_Update;
            if (processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request);

            return result.Match<IActionResult>(task =>
            {
                return CreatedAtAction(nameof(Update), task);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }

    }
}

