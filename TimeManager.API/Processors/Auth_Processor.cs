using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Authentication;
using TimeManager.API.Processors.AuthenticationProcessor;

namespace TimeManager.API.Processors
{
    public class Auth_Processor : Processor
    {
        public Auth_Processor(DataContext context) : base(context) { }

        
        public bool IsAuth(Token token)
        {
            if(token == null) return false;

            var utilities = new User_Utilities(_context);
            if (_context.Tokens.Contains(token))
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == token.userId);
                return utilities.IsAuthorised(user);
            };

            return false;
        }
    }
}
