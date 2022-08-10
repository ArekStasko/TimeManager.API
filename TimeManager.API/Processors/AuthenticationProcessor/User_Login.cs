using TimeManager.API.Data.Response;
using TimeManager.API.Data;
using TimeManager.API.Authentication;

namespace TimeManager.API.Processors.AuthenticationProcessor
{
    public class User_Login : Processor
    {
        public User_Login(DataContext context) : base(context) { }
        public Response<Token> Login(UserDTO data)
        {
            Response<Token> response;
            try
            {
                User_Utilities userHash = new User_Utilities(_context);
                var user = _context.Users.FirstOrDefault(u => u.UserName == data.UserName);

                if (userHash.VerifyPasswordHash(data.Password, user))
                {

                    Token token = userHash.CreateToken(user);
                    response = new Response<Token>(token);
                    return response;
                }

                throw new Exception("User not found !");
            }
            catch (Exception ex)
            {
                response = new Response<Token>(ex, "Whoops something went wrong");
                return response;
            }
        }
    }
}
