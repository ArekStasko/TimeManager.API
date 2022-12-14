﻿using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_GetById : Processor<ITaskSet_GetById>, ITaskSet_GetById
    {
        public TaskSet_GetById(DataContext context, Logger<ITaskSet_GetById> logger) : base(context, logger) { }

        public async Task<ActionResult<TaskSet>> Execute(Request<int> request)
        {
            try
            {
                var taskSet = _context.ActTaskSets.Single(tsk => tsk.Id == request.Data && tsk.UserId == request.userId);

                _logger.LogInformation("Successfully completed TaskSet_GetById processor execution");
                return taskSet;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                throw new Exception(ex.Message);
            }
        }
    }
}