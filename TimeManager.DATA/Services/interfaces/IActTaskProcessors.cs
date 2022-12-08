using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;
using TimeManager.DATA.Controllers.ActTaskControllers;

namespace TimeManager.DATA.Services.interfaces
{
    public interface IActTaskProcessors 
    {
        public Task<ActionResult<Response<List<ActTask>>>> ActTask_Get(int userId);
        public Task<ActionResult<Response<ActTask>>> ActTask_GetById(int actTaskId, int userId);
        //public Task<ActionResult<Response<List<actTask>>>> GetByCategory(int categoryId, int userId);
        public Task<ActionResult<ActTask>> ActTask_Post(Request<ActTask> request);
        public Task<ActionResult<ActTask>> ActTask_Delete(int actTaskId, int userId);
        public Task<ActionResult<ActTask>> ActTask_Update(Request<ActTask> request);
       
    }
}
