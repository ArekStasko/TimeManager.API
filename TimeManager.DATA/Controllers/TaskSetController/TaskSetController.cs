using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.Container;

namespace TimeManager.DATA.Controllers.TaskSetControllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskSetController : ControllerBase
    {
        private readonly IProcessors _processors;

        public TaskSetController(IProcessors processors) => _processors = processors;

        [HttpPost(Name = "GetTaskSetById")]
        public async Task<IActionResult> GetById(Request<Guid> request)
        {
            var processor = _processors.taskSet_GetById;
            if(processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request.Data, request.userId);

            return result.Match<IActionResult>(taskSet =>
            {
                return CreatedAtAction(nameof(GetById), taskSet);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }

        [HttpPost(Name = "GetTaskSets")]
        public async Task<IActionResult> GetAll (Request<string> request)
        {
            var processor = _processors.taskSet_GetAll;
            if (processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request.userId);
            return result.Match<IActionResult>(taskSet =>
            {
                return CreatedAtAction(nameof(GetAll), taskSet);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }

        [HttpPost(Name = "DeleteTaskSet")]
        public async Task<IActionResult> Delete(Request<TaskSet> request)
        {
            var processor = _processors.taskSet_Delete;
            if (processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request.Data.Id, request.userId);

            return result.Match<IActionResult>(success =>
            {
                return CreatedAtAction(nameof(Delete), success);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }

        [HttpPost(Name = "PostTaskSet")]
        public async Task<IActionResult> Post(Request<TaskSet> request)
        {
            var processor = _processors.taskSet_Post;
            if (processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request);

            return result.Match<IActionResult>(success =>
            {
                return CreatedAtAction(nameof(Post), success);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }

        [HttpPost(Name = "UpdateTaskSet")]
        public async Task<IActionResult> Update(Request<TaskSet> request)
        {
            var processor = _processors.taskSet_Update;
            if (processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request);

            return result.Match<IActionResult>(success =>
            {
                return CreatedAtAction(nameof(Update), success);
            }, exception =>
            {
                return BadRequest(exception);
            });
            }

    }
}
