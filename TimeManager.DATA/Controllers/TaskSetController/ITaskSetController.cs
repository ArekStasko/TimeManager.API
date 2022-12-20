using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;


namespace TimeManager.DATA.Controllers.TaskSetControllers
{
    public interface ITaskSetController
    {
        public Task<IActionResult> GetById(Request<int> request);
        public Task<IActionResult> GetAll(Request<string> request);
        public Task<IActionResult> Delete(Request<TaskSet> request);
        public Task<IActionResult> Post(Request<TaskSet> request);
        public Task<IActionResult> Update(Request<TaskSet> request);

    }
}
