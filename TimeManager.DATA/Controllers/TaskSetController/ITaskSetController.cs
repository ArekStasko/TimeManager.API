using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Controllers.TaskSetControllers
{
    public interface ITaskSetController
    {
        public Task<ActionResult<Response<List<TaskSet>>>> GetById(Request<int> request);
        public Task<ActionResult<Response<List<TaskSet>>>> GetAll(Request<string> request);
        public Task<ActionResult<Response<List<TaskSet>>>> Delete(Request<TaskSet> request);
        public Task<ActionResult<Response<List<TaskSet>>>> Post(Request<TaskSet> request);
        public Task<ActionResult<Response<List<TaskSet>>>> Update(Request<TaskSet> request);

    }
}
