namespace TimeManager.DATA.Data.Response
{
    public interface IApiException
    {
        public int Status { get; }
        public string Description { get; }
    }
}
