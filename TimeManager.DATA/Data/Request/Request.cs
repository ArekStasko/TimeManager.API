
namespace TimeManager.DATA.Data
{
    public class Request<T> : IRequest<T>
    {
        public T Data { get; set; }
        public Guid userId { get; set; }
    }
}