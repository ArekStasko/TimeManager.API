using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.ActivityProcessor
{
    public interface IvwActivityCategory_GetAll
    {
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Get(Token token);
    }
}
