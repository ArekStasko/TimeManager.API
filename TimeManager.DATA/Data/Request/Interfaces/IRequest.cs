namespace TimeManager.DATA.Data
{
    public interface IRequest<T>
    {
        public T Data { get; set; }
        public Guid userId { get; set; }

    }
}
