using TimeManager.API.Data;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public static class CategoryProcessor_Factory
    {
        public static ICategory_Add GetCategory_Add(this DataContext _context) => new Category_Add(_context);
        public static ICategory_Delete GetCategory_Delete(this DataContext _context) => new Category_Delete(_context);
        public static ICategory_Get GetCategory_Get(this DataContext _context) => new Category_Get(_context);
        public static ICategory_Update GetCategory_Update(this DataContext _context) => new Category_Update(_context);
    }
}
