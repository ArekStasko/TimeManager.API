namespace TimeManager.DATA.Data.Response
{
    public interface IResponse<T>
    {
        public T Data { get; set; }
        public ApiException Exception { get; set; }
    }
}
