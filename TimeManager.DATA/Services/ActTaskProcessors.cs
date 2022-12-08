using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using Newtonsoft.Json;
using TimeManager.DATA.Controllers.ActTaskControllers;
using TimeManager.DATA.Processors.actTaskProcessor;
using TimeManager.DATA.Services.interfaces;

namespace TimeManager.DATA.Services
{
    public class ActTaskProcessors : IActTaskProcessors
    {
        public readonly DataContext _context;
        private readonly ILogger<ActTaskSetController> _logger;

        public ActTaskProcessors(DataContext context, ILogger<ActTaskSetController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public Task<ActionResult<Response<List<ActTask>>>> ActTask_Get(int userId)
        {
            IActTask_GetAll processor = new ActTask_GetAll(_context, _logger);
            return processor.Get(userId);
        }

        public Task<ActionResult<Response<ActTask>>> ActTask_GetById(int actTaskId, int userId)
        {
            IActTask_GetById processor = new ActTask_GetById(_context, _logger);
            return processor.Get(actTaskId, userId);
        }
        /*
        public Task<ActionResult<Response<List<actTask>>>> GetByCategory(int categoryId, int userId)
        {
            IactTask_GetByCategory processor = new actTask_GetByCategory(_context, _logger);
            return processor.Get(categoryId, userId);
        }
        */
        public Task<ActionResult<ActTask>> ActTask_Post(Request<Data.ActTask> request)
        {
            IActTask_Post processor = new ActTask_Post(_context, _logger);
            return processor.Post(request);
        }

        public Task<ActionResult<ActTask>> ActTask_Delete(int actTaskId, int userId)
        {
            IActTask_Delete processor = new ActTask_Delete(_context, _logger);
            return processor.Delete(actTaskId, userId);
        }

        public Task<ActionResult<ActTask>> ActTask_Update(Request<Data.ActTask> request)
        {
            IActTask_Update processor = new ActTask_Update(_context, _logger);
            return processor.Update(request);
        }
      }
    }
