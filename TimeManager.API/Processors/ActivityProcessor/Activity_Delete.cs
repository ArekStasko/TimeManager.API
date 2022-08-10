using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_Delete : Auth_Processor, IActivity_Delete
    {

        public vwActivityCategory_Delete(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Delete(Request<int> request)
        {
            Response<List<vwActivityCategory>> response;
            try
            {
                if (!IsAuth(request.Token)) throw new Exception("You have to be logged in");
                var activity = _context.Activities.Single(act => act.Id == request.Data);
                _context.Activities.Remove(activity);
                _context.SaveChanges();

                IvwActivityCategory_GetAll vwActivityCategory_GetAll = new vwActivityCategory_GetAll(_context);
                return await vwActivityCategory_GetAll.Get(request.Token);
            }
            catch (Exception ex)
            {
                response = new Response<List<vwActivityCategory>>(ex, "Whoops, something went wrong");
                return response;
            }

        }
    }
}
