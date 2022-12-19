﻿using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.TaskProcessor.Interfaces
{
    public interface ITask_GetAll
    {
        public Task<Result<List<Task_>>> Execute(int userId);
    }
}
