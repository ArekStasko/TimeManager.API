using TimeManager.API.Data.Response;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.AuthenticationProcessor
{
    public class User_Register : Processor
    {
        public User_Register(DataContext context) : base(context) { }
        public Response<User> Register(UserDTO data)
        {
            Response<User> response;
            try
            {
                User_Utilities hashGenerator = new User_Utilities(_context);
                Tuple<byte[], byte[]> hash = hashGenerator.CreatePasswordHash(data.Password);

                User user = new User(data.UserName, hash.Item1, hash.Item2);
                _context.Users.Add(user);
                _context.SaveChanges();

                response = new Response<User>(user);
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<User>(ex, "Whoops something went wrong");
                return response;
            }
        }
    }
}
