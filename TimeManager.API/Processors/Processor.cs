using TimeManager.API.Data;

namespace TimeManager.API.Processors
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
