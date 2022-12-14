using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;
using TimeManager.DATA.Services.Container;

namespace TimeManager.DATA.Controllers.ActTaskControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActTaskSetController : ControllerBase, IActTaskSetController
    {
        private readonly IProcessors _processors;
        private readonly IMQManager _mqManager;

        public ActTaskSetController(IProcessors processors, IMQManager mqManager)
        {
            _processors = processors;
            _mqManager = mqManager;
        } 


        [HttpPost(Name = "GetTasks")]
        public async Task<ActionResult<Response<List<Task>>>> Get(Request<string> request)
        {
            try
            {
                var processor = _processors.task_GetAll;
                if(processor == null) throw new ArgumentNullException(nameof(processor));

                return Ok(await processor.Execute(request.userId));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "GetTaskById")]
        public async Task<ActionResult<Response<Task>>> GetById(Request<int> request)
        {
            try
            {
                var processor = _processors.task_GetById;
                if(processor == null) throw new ArgumentNullException(nameof(processor));

                return Ok(await processor.Execute(request.Data, request.userId));
            }
            catch(ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "PostTask")]
        public async Task<ActionResult<Response<List<Task>>>> Post(Request<Data.Task_> request)
        {
            try
            {
                var processor = _processors.task_Post;
                if(processor == null) throw new ArgumentNullException(nameof(processor));

                var activity = processor.Execute(request);

                _mqManager.Publish(
                    activity,
                    "entity.activity.post",
                    "direct",
                    "Activity_Post"
                );

                var processor_Get = _processors.task_GetAll;
                if (processor_Get == null) throw new ArgumentNullException(nameof(processor_Get));

                return Ok(await processor_Get.Execute(request.userId));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteTask")]
        public async Task<ActionResult<Response<List<Task>>>> Delete(Request<int> request)
        {
            try
            {
                var processor = _processors.task_Delete;
                if(processor == null) throw new ArgumentNullException(nameof(processor));

                var activity = processor.Execute(request.Data, request.userId);

                _mqManager.Publish(
                    activity,
                    "entity.activity.delete",
                    "direct",
                    "Activity_Delete"
                );

                var processor_Get = _processors.task_GetAll;
                if (processor_Get == null) throw new ArgumentNullException(nameof(processor_Get));

                return Ok(await processor_Get.Execute(request.userId));
            }
            catch(ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(Name = "UpdateTask")]
        public async Task<ActionResult<Response<List<Task>>>> Update(Request<Data.Task_> request)
        {
            try
            {
                var processor = _processors.task_Update;
                if (processor == null) throw new ArgumentNullException(nameof(processor));

                var activity = await processor.Execute(request);

                _mqManager.Publish(
                    activity,
                    "entity.activity.update",
                    "direct",
                    "Activity_Update"
                );

                return Ok(activity);
            }
            catch(ArgumentException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
