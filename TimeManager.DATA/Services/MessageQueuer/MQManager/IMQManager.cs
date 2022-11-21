namespace TimeManager.DATA.Services.MessageQueuer
{
    public interface IMQManager
    {
        public void Publish<T>(T message, string exchangeName, string exchangeType, string routeKey) where T : class;
    }
}
