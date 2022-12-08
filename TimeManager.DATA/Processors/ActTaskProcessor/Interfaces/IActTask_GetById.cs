using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public interface IActTask_GetById
    {
        public Task<ActionResult<Response<ActTask>>> Get(int actTaskId, int userId);
    }
}
