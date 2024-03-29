﻿using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Controllers.TaskSetControllers;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_GetAll : Processor<TaskSetController>, ITaskSet_GetAll
    {
        public TaskSet_GetAll(DataContext context, ILogger<TaskSetController> logger) : base(context, logger) { }

        public async Task<Result<List<TaskSet>>> Execute(Guid userId)
        {
            try
            {
                var taskSets = _context.TaskSets.Where(tsk => tsk.UserId == userId).ToList();

                _logger.LogInformation("Successfully completed TaskSet_GetAll processor execution");
                return new Result<List<TaskSet>>(taskSets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                return new Result<List<TaskSet>>(ex);
            }
        }
    }
}
