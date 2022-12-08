using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;

namespace TimeManager.DATA.Processors.actTaskProcessor
{
    public interface IActTask_Delete
    {
        public Task<ActionResult<ActTask>> Delete(int actTaskId, int userId);
    }
}
