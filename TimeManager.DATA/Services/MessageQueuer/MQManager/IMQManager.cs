using RabbitMQ.Client;

namespace TimeManager.DATA.Services.MessageQueuer
{
    public interface IMQManager
    {
        public IModel channel { get; }
        public bool Publish<T>(T message, string exchangeName, string exchangeType, string routeKey) where T : class;
    }
}
