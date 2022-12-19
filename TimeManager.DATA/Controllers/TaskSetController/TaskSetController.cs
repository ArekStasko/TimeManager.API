using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;
using TimeManager.DATA.Services.Container;

namespace TimeManager.DATA.Controllers.TaskSetControllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskSetController : ControllerBase, ITaskSetController
    {
        private readonly IProcessors _processors;
        private readonly IMQManager _mqManager;

        public TaskSetController(IProcessors processors, IMQManager mqManager)
        {
            _processors = processors;
            _mqManager = mqManager;
        }

        [HttpPost(Name = "GetTaskSetById")]
        public async Task<ActionResult<Response<List<TaskSet>>>> GetById(Request<int> request)
        {
            try
            {
                var processor = _processors.taskSet_GetById;
                if(processor == null) throw new ArgumentNullException(nameof(processor));

                return Ok(await processor.Execute(request));
            }
            catch(ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "GetTaskSets")]
        public async Task<ActionResult<Response<List<TaskSet>>>> GetAll (Request<string> request)
        {
            try
            {
                var processor = _processors.taskSet_GetAll;
                if (processor == null) throw new ArgumentNullException(nameof(processor));

                return Ok(await processor.Execute(request.userId));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "DeleteTaskSet")]
        public async Task<ActionResult<Response<List<TaskSet>>>> Delete(Request<TaskSet> request)
        {
            try
            {
                var processor = _processors.taskSet_Delete;
                if (processor == null) throw new ArgumentNullException(nameof(processor));

                return Ok(processor.Execute(request));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "PostTaskSet")]
        public async Task<ActionResult<Response<List<TaskSet>>>> Post(Request<TaskSet> request)
        {
            try
            {
                var processor = _processors.taskSet_Post;
                if (processor == null) throw new ArgumentNullException(nameof(processor));

                return Ok(await processor.Execute(request));
            }
            catch(ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "UpdateTaskSet")]
        public async Task<ActionResult<Response<List<TaskSet>>>> Update(Request<TaskSet> request)
        {
            try
            {
                var processor = _processors.taskSet_Update;
                if (processor == null) throw new ArgumentNullException(nameof(processor));

                return Ok(await processor.Execute(request));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
