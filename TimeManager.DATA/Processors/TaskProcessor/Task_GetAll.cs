﻿using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.TaskControllers;
using TimeManager.DATA.Processors.TaskProcessor.Interfaces;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace TimeManager.DATA.Processors.TaskProcessor
{
    public class Task_GetAll : Processor<TaskController>, ITask_GetAll
    {
        public Task_GetAll(DataContext context, ILogger<TaskController> logger) : base(context, logger) { }
        public async Task<Result<List<Task_>>> Execute(Guid userId)
        {
            try
            {
                var tasks = _context.Tasks.ToList();
                tasks = tasks.Where(a => a.UserId == userId).ToList();
                return new Result<List<Task_>>(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<List<Task_>>(ex); 
            }
        }
    }
}
