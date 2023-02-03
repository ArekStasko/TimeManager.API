using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.DTO;

namespace TimeManager.DATA.Processors.TaskSetProcessor
{
    public interface ITaskSet_Update
    {
        public Task<Result<bool>> Execute(Request<TaskSetDTO> request);
    }
}
