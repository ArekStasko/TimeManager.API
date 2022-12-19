using LanguageExt.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Response;


namespace TimeManager.DATA.Processors.TaskProcessor.Interfaces
{
    public interface ITask_Update
    {
        public Task<Result<bool>> Execute(Request<Data.Task_> request);
    }
}
