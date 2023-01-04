using TimeManager.DATA.Services.MessageQueuer;

namespace TimeManager.DATA.Tests.Data
{
    public class MockMQ_True : IMQManager
    {
        public bool Publish<T>(T message, string exchangeName, string exchangeType, string routeKey) where T : class
        {
            return true;
        }
    }

    public class MockMQ_False : IMQManager
    {
        public bool Publish<T>(T message, string exchangeName, string exchangeType, string routeKey) where T : class
        {
            return false;
        }
    }
}
