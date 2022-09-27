using TimeManager.API.Data;
using TimeManager.API.Controllers.vwActivityCategoryControllers;

namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public static class ActivityProcessor_Factory
    {
        public static IActivity_Add GetActivity_Add(this DataContext _context, ILogger<ActivityController> logger) => new Activity_Add(_context, logger);
        public static IActivity_Delete GetActivity_Delete(this DataContext _context, ILogger<ActivityController> logger) => new vwActivityCategory_Delete(_context, logger);
        public static IvwActivityCategory_GetAll GetvwActivityCategory_GetAll(this DataContext _context, ILogger<ActivityController> logger) => new vwActivityCategory_GetAll(_context, logger);
        public static IvwActivityCategory_GetByCategory GetvwActivityCategory_GetByCategory(this DataContext _context, ILogger<ActivityController> logger) => new vwActivityCategory_GetByCategory(_context, logger);
        public static IvwActivityCategory_GetById GetvwActivityCategory_GetById(this DataContext _context, ILogger<ActivityController> logger) => new vwActivityCategory_GetById(_context, logger);
        public static IActivity_Update GetActivity_Update(this DataContext _context, ILogger<ActivityController> logger) => new vwActivityCategory_Update(_context, logger);
    }
}
