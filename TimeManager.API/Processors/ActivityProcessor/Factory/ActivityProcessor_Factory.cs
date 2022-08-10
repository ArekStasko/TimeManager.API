using TimeManager.API.Data;

namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public static class ActivityProcessor_Factory
    {
        public static IActivity_Add GetActivity_Add(this DataContext _context) => new Activity_Add(_context);
        public static IActivity_Delete GetActivity_Delete(this DataContext _context) => new vwActivityCategory_Delete(_context);
        public static IvwActivityCategory_GetAll GetvwActivityCategory_GetAll(this DataContext _context) => new vwActivityCategory_GetAll(_context);
        public static IvwActivityCategory_GetByCategory GetvwActivityCategory_GetByCategory(this DataContext _context) => new vwActivityCategory_GetByCategory(_context);
        public static IvwActivityCategory_GetById GetvwActivityCategory_GetById(this DataContext _context) => new vwActivityCategory_GetById(_context);
        public static IActivity_Update GetActivity_Update(this DataContext _context) => new vwActivityCategory_Update(_context);
    }
}
