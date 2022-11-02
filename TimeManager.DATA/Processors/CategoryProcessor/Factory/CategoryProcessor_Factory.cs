using TimeManager.DATA.Data;
using TimeManager.DATA.Controllers.CategoryControllers;

namespace TimeManager.DATA.Processors.CategoryProcessor
{
    public static class CategoryProcessor_Factory
    {
        public static ICategory_Add GetCategory_Add(this DataContext _context, ILogger<CategoryController> logger) => new Category_Add(_context, logger);
        public static ICategory_Delete GetCategory_Delete(this DataContext _context, ILogger<CategoryController> logger) => new Category_Delete(_context, logger);
        public static ICategory_Get GetCategory_Get(this DataContext _context, ILogger<CategoryController> logger) => new Category_Get(_context, logger);
        public static ICategory_Update GetCategory_Update(this DataContext _context, ILogger<CategoryController> logger) => new Category_Update(_context, logger);
    }
}
