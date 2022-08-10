using TimeManager.API.Data;

namespace TimeManager.API.Processors
{
    public class Processor
    {
        protected readonly DataContext _context;

        public Processor(DataContext context)
        {
            _context = context;
        }
    }
}
