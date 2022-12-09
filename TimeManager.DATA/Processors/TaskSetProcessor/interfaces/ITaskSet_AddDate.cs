﻿using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskSetProcessor.interfaces
{
    public interface ITaskSet_AddDate
    {
        public Task<ActionResult<TaskSet>> Execute(Request<TaskSet> request);
    }
}
