using TimeManager.API.Authentication;

namespace TimeManager.API.Data
{
    public class Request<T> : IRequest<T>
    {
        public T Data { get; set; }
        public Token Token { get; set; }
    }
}