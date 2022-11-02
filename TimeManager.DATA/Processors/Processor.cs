using TimeManager.DATA.Data;

namespace TimeManager.DATA.Processors
{
    public class Processor<T>
    {
        protected readonly DataContext _context;
        protected readonly ILogger<T> _logger;

        public Processor(DataContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
