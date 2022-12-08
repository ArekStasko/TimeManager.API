using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public interface IActTask_Update
    {
        public Task<ActionResult<ActTask>> Update(Request<Data.ActTask> request);
    }
}
