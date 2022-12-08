using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public interface IActTask_Post
    {
        public Task<ActionResult<ActTask>> Post(Request<ActTask> request);
    }
}
