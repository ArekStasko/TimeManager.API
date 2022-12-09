using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Controllers.ActTaskSetControllers
{
    public interface ITaskSetController
    {
        public Task<ActionResult<Response<List<Task>>>> Update(Request<Data.Task_> request);

    }
}
