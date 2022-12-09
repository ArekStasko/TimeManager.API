using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;

namespace TimeManager.DATA.Services.interfaces
{
    public interface ITaskProcessors 
    {
        public Task<ActionResult<Response<List<Task_>>>> ActTask_Get(int userId);
        public Task<ActionResult<Response<Task_>>> ActTask_GetById(int actTaskId, int userId);
        //public Task<ActionResult<Response<List<actTask>>>> GetByCategory(int categoryId, int userId);
        public Task<ActionResult<Task_>> ActTask_Post(Request<Task_> request);
        public Task<ActionResult<Task_>> ActTask_Delete(int actTaskId, int userId);
        public Task<ActionResult<Task_>> ActTask_Update(Request<Task_> request);
       
    }
}
