﻿using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors.TaskProcessor.Interfaces
{
    public interface ITask_Post
    {
            public Task<ActionResult<Task_>> Execute(Request<Task_> request);
    }
}
