﻿using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public interface IActivity_Delete
    {
        public Task<ActionResult<Response<List<Activity>>>> Delete(int activityId, int userId);
    }
}
