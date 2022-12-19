using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;
using TimeManager.DATA.Services.Container;
using LanguageExt.Common;

namespace TimeManager.DATA.Controllers.TaskControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase, ITaskController
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
            if(processor == null) throw new ArgumentNullException(nameof(processor));

            var result = await processor.Execute(request.userId);
            
            return result.Match<IActionResult>(task =>
            {
                return CreatedAtAction("Get", task);
            },exception =>
            {
                return BadRequest(exception);
            });
        }

        [HttpPost(Name = "GetTaskById")]
        public async Task<IActionResult> GetById(Request<int> request)
        {
            var processor = _processors.task_GetById;
            if(processor == null) return BadRequest(new ArgumentNullException(nameof(processor)));

            var result = await processor.Execute(request.Data, request.userId);

            return result.Match<IActionResult>(task =>
            {
                return CreatedAtAction("Get", task);
            }, exception =>
            {
                return BadRequest(exception);
            });
        }

        [HttpPost(Name = "PostTask")]
        public async  Result<List<Task>> Post(Request<Task_> request)
        {
                var processor = _processors.task_Post;
                if(processor == null) throw new ArgumentNullException(nameof(processor));

                var activity = processor.Execute(request);

                var processor_Get = _processors.task_GetAll;
                if (processor_Get == null) throw new ArgumentNullException(nameof(processor_Get));

                return Ok(processor_Get.Execute(request.userId));
        }

        [HttpDelete(Name = "DeleteTask")]
        public async Result<List<Task_>> Delete(Request<int> request)
        {

                var processor = _processors.task_Delete;
                if(processor == null) throw new ArgumentNullException(nameof(processor));

                var result = processor.Execute(request.Data, request.userId);



                var processor_Get = _processors.task_GetAll;
                if (processor_Get == null) throw new ArgumentNullException(nameof(processor_Get));


                return Ok(processor_Get.Execute(request.userId));
        }

        [HttpPost(Name = "UpdateTask")]
        public async Result<Task_> Update(Request<Task_> request)
        {
                var processor = _processors.task_Update;
                if (processor == null) throw new ArgumentNullException(nameof(processor));

                var activity = processor.Execute(request);

                return Ok(activity);
        }

    }

