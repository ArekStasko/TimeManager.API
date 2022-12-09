using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using Newtonsoft.Json;
using TimeManager.DATA.Controllers.ActTaskControllers;
using TimeManager.DATA.Processors.TaskProcessor;
using TimeManager.DATA.Services.interfaces;

namespace TimeManager.DATA.Services
{
    public class TaskProcessors : ITaskProcessors
    {
        public readonly DataContext _context;
        private readonly ILogger<ActTaskSetController> _logger;

        public TaskProcessors(DataContext context, ILogger<ActTaskSetController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public Task<ActionResult<Response<List<Task_>>>> ActTask_Get(int userId)
        {
            ITask_GetAll processor = new Task_GetAll(_context, _logger);
            return processor.Execute(userId);
        }

        public Task<ActionResult<Response<Task_>>> ActTask_GetById(int actTaskId, int userId)
        {
            ITask_GetById processor = new Task_GetById(_context, _logger);
            return processor.Execute(actTaskId, userId);
        }
        /*
        public Task<ActionResult<Response<List<actTask>>>> GetByCategory(int categoryId, int userId)
        {
            IactTask_GetByCategory processor = new actTask_GetByCategory(_context, _logger);
            return processor.Get(categoryId, userId);
        }
        */
        public Task<ActionResult<Task_>> ActTask_Post(Request<Data.Task_> request)
        {
            ITask_Post processor = new Task_Post(_context, _logger);
            return processor.Execute(request);
        }

        public Task<ActionResult<Task_>> ActTask_Delete(int actTaskId, int userId)
        {
            ITask_Delete processor = new Task_Delete(_context, _logger);
            return processor.Execute(actTaskId, userId);
        }

        public Task<ActionResult<Task_>> ActTask_Update(Request<Data.Task_> request)
        {
            ITask_Update processor = new Task_Update(_context, _logger);
            return processor.Execute(request);
        }
      }
    }
