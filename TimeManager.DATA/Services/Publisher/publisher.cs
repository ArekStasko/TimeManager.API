using RabbitMQ.Client;
using System.Text;

namespace TimeManager.DATA.Services.Publisher
{
    public class publisher : IPublisher
    {
        public void Publish()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "entity-queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            var message = "test message";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", "entity-queue", null, body);
            
        }
    }
}
