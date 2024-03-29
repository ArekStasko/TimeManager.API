﻿using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Controllers.TaskSetControllers;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public class TaskSet_Delete : Processor<TaskSetController>, ITaskSet_Delete
    {
        public TaskSet_Delete(DataContext context, ILogger<TaskSetController> logger, IMQManager mqManager) : base(context, logger, mqManager) { }

        public async Task<Result<bool>> Execute(Guid taskSetId, Guid userId)
        {
            try{

                var taskSetRecord = _context.TaskSets.Single(tsk => tsk.Id == taskSetId && tsk.UserId == userId);

                var toDelete = _context.TaskSets.OrderBy(e => e.Id).Include(e => e.TaskOccurencies);
                var taskSet = toDelete.Single(tsk => tsk.Id == taskSetId && tsk.UserId == userId);
                
                _context.TaskSets.Remove(taskSet);

                bool succ = _mqManager.Publish(
                   taskSetRecord,
                   "entity.taskSet.delete",
                   "direct",
                   "taskSet_Delete"
               );

                if (!succ) return new Result<bool>(false);

                _context.SaveChanges();

                _logger.LogInformation("Successfully completed TaskSet_Delete processor execution");
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
