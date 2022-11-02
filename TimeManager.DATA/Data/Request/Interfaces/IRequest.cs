namespace TimeManager.DATA.Data
{
    public interface IRequest<T>
    {
        public T Data { get; set; }
        public int userId { get; set; }

    }
}
