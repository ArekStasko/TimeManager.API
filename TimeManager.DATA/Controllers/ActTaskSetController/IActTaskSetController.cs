using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Controllers.ActTaskSetControllers
{
    public interface IActTaskSetController
    {
        public Task<ActionResult<Response<List<Task>>>> Update(Request<Data.ActTask> request);

    }
}
