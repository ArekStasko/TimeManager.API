using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public interface IActTask_GetAll
    {
        public Task<ActionResult<Response<List<ActTask>>>> Get(int userId);
    }
}
