using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Azil.Animals.Broker
{
    public class MessageBroker : IMessageBroker
    {
        private readonly IConfiguration configuration;
        public MessageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IConnection CreateConnection()
        {
            var hostName = configuration.GetSection("MessageBroker:HostName").Value;
            var factory = new ConnectionFactory
            {
                HostName = configuration.GetSection("MessageBroker:HostName").Value,
                Port = int.Parse(configuration.GetSection("MessageBroker:Port").Value),
                UserName = configuration.GetSection("MessageBroker:Username").Value,
                Password = configuration.GetSection("MessageBroker:Password").Value
            };

            return factory.CreateConnection();
        }

        public void Publish<T>(T message)
        {
            var connection = CreateConnection();
            using var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", "animals", body: body);
        }
    }
}
