using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.ActivityControllers;

namespace TimeManager.DATA.Processors.ActivityProcessor
{
    public static class ActivityProcessor_Factory
    {
        public static IActivity_Add GetActivity_Add(this DataContext _context, ILogger<ActivityController> logger) => new Activity_Add(_context, logger);
        public static IActivity_Delete GetActivity_Delete(this DataContext _context, ILogger<ActivityController> logger) => new Activity_Delete(_context, logger);
        public static IActivity_GetAll GetActivity_GetAll(this DataContext _context, ILogger<ActivityController> logger) => new Activity_GetAll(_context, logger);
        public static IActivity_GetByCategory GetActivity_GetByCategory(this DataContext _context, ILogger<ActivityController> logger) => new Activity_GetByCategory(_context, logger);
        public static IActivity_GetById GetActivity_GetById(this DataContext _context, ILogger<ActivityController> logger) => new Activity_GetById(_context, logger);
        public static IActivity_Update GetActivity_Update(this DataContext _context, ILogger<ActivityController> logger) => new Activity_Update(_context, logger);
    }
}
