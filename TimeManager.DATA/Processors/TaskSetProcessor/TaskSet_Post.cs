﻿using AutoMapper;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Controllers.TaskSetControllers;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.DTO;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Post : Processor<TaskSetController>, ITaskSet_Post
    { 
        public TaskSet_Post(DataContext context, ILogger<TaskSetController> logger, IMQManager mqManager, IMapper mapper) : base(context, logger, mqManager, mapper) { }

        public async Task<Result<bool>> Execute(Request<TaskSetDTO> request)
        {
            try
            {
                TaskSet taskSet = _mapper.Map<TaskSet>(request.Data);
                taskSet.Id = Guid.NewGuid();
                taskSet.UserId = request.userId;
                _context.TaskSets.Add(taskSet);

                bool succ = _mqManager.Publish(
                   taskSet,
                   "entity.taskSet.post",
                   "direct",
                   "taskSet_Post"
               );

                if (!succ) return new Result<bool>(false);

                _context.SaveChanges();

                _logger.LogInformation("Successfully completed TaskSet_Post processor execution");
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
