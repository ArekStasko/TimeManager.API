using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Controllers.ActTaskSetControllers
{
    public interface ITaskSetController
    {
        public Task<ActionResult<Response<List<TaskSet>>>> DeleteDate(Request<Task_> request);
        public Task<ActionResult<Response<List<TaskSet>>>> AddDate(Request<Task_> request);
        public Task<ActionResult<Response<List<TaskSet>>>> GetById(Request<Task_> request);
        public Task<ActionResult<Response<List<TaskSet>>>> GetAll(Request<Task_> request);
        public Task<ActionResult<Response<List<TaskSet>>>> Delete(Request<Task_> request);
        public Task<ActionResult<Response<List<TaskSet>>>> Post(Request<Task_> request);
        public Task<ActionResult<Response<List<TaskSet>>>> Update(Request<Task_> request);

    }
}
