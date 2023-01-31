using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DATA.Data;
using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Processors
{
    public class Processor<T>
    {
        protected readonly DataContext _context;
        protected readonly ILogger<T> _logger;
        protected readonly IMQManager _mqManager;
        protected readonly IMapper _mapper;

        public Processor(DataContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Processor(DataContext context, ILogger<T> logger, IMQManager mqManager)
        {
            _context = context;
            _logger = logger;
            _mqManager = mqManager;
        }
        
        public Processor(DataContext context, ILogger<T> logger, IMQManager mqManager, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mqManager = mqManager;
            _mapper = mapper;
        }
    }
}
