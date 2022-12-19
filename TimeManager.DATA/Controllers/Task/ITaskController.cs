using TimeManager.DATA.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data.Response;
using LanguageExt.Common;

namespace TimeManager.DATA.Controllers.TaskControllers
{
    public interface ITaskController
    {
        public Result<List<Task_>> Get(Request<string> request);
        public Result<Task_> GetById(Request<int> request);
        public Result<List<Task_>> Post(Request<Task_> request);
        public Result<List<Task_>> Delete(Request<int> request);
        public Result<Task_> Update(Request<Task_> request);

    }
}
