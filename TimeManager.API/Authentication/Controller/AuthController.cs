using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TimeManager.API.Data.Response;
using TimeManager.API.Data;
using TimeManager.API.Processors.AuthenticationProcessor;

namespace TimeManager.API.Authentication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase, IAuthController
    {
        private readonly DataContext _context;
        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Response<User>>> Register(UserDTO request)
        {
            User_Register register = new User_Register(_context);
            var User = register.Register(request);
            return Ok(User);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<string>>> Login(UserDTO request)
        {
            User_Login login = new User_Login(_context);
            var User = login.Login(request);            
            return Ok(User);
        }


    }
}
