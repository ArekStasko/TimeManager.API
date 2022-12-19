using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using LanguageExt.Common;

namespace TimeManager.DATA.Controllers.TaskControllers
{
    public interface ITaskController
    {
        public Task<IActionResult> Get(Request<string> request);
        public Task<IActionResult> GetById(Request<int> request);
        public Task<IActionResult> Post(Request<Task_> request);
        public Task<IActionResult> Delete(Request<int> request);
        public Task<IActionResult> Update(Request<Task_> request);

    }
}
