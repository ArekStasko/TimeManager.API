using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Controllers.ActTaskControllers
{
    public interface IActTaskSetController
    {
        public Task<ActionResult<Response<List<Task>>>> Get(Request<string> request);
        public Task<ActionResult<Response<Task>>> GetById(Request<int> request);
       // public Task<ActionResult<Response<List<Activity>>>> GetByCategory(Request<int> request);
        public Task<ActionResult<Response<List<Task>>>> Post(Request<Data.ActTask> request);
        public Task<ActionResult<Response<List<Task>>>> Delete(Request<int> request);
        public Task<ActionResult<Response<List<Task>>>> Update(Request<Data.ActTask> request);

    }
}
