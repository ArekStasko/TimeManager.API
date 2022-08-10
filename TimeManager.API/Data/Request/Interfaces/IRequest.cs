namespace TimeManager.API.Data
{
    public interface IRequest<T>
    {
        public T Data { get; set; }
    }
}
